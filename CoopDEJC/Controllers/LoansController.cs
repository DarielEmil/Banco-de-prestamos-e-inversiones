using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;
using CoopDEJC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using CoopDEJC.Models.CoopDBModels;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Prestamo = CoopDEJC.Models.CoopDBModels.Prestamo;
using Cliente = CoopDEJC.Models.CoopDBModels.Cliente;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis;
using NuGet.Protocol.Plugins;
using CoopDEJC.Models.VistasModels;

namespace CoopDEJC.Controllers
{
    public class LoansController : Controller
    {
        private readonly IConverter _converter;

        private readonly CoopContext _context;
        private Cliente? cliente;
        private Prestamo? prestamo1;


       public LoansController(CoopContext context,IConverter converter)
        {
            _converter = converter;
            _context = context;
        }
        //Vista de prestamos
        public IActionResult Loans()
        {
            LoansModel lmodel = new LoansModel();
            //Prestamo prestamo = new Prestamo();
            //prestamo.Monto = 5000;

            var prestamos = (from d in _context.Prestamos
                             where d.Usuario == cliente
                             select d).ToList();

            //lmodel.Prestamos.Add(prestamo);
            lmodel.Prestamos = prestamos;

           

            //foreach (var prestamo in prestamos)
            //{

            //}




            return View(lmodel);
        }

        //Action que recibe los campos y los manda al DB
        public IActionResult LoansGet(int lamount,int lfee, DateTime ldate, DateTime lfeedate,int amount,string id,string objtype,string location)
        {
     
            //creacion del prestamo
            Prestamo prestamo = new Prestamo();

            prestamo.Monto = lamount;
            prestamo.Interes = lfee;
            prestamo.FechaInicio = ldate;
            prestamo.FechaFin = lfeedate;
            prestamo.ValorGarantias = amount;
            prestamo.Tipo = "Personal";
            prestamo.CuotasPagadas = 12;
            var fiador = _context.Clientes.FirstOrDefault(f => f.Cedula == id);
            prestamo.Fiador= fiador;
            prestamo.Usuario = cliente;

            //creacion de la garantia
            Garantia garantia = new Garantia();

            garantia.Ubicacion = location;
            garantia.Tipo = objtype;
            garantia.Monto = amount;
            garantia.Prestamo= prestamo;

            try
            {
                _context.Prestamos.Add(prestamo);
                _context.Garantias.Add(garantia);

                _context.SaveChanges();

            }catch (Exception ex)
            {
                Console.WriteLine("error al guardar: " + ex);
            }
            return RedirectToAction("Loans");
        }


        public IActionResult LoansReport()
        {
            Prestamo prestamo = new()
            {
                PrestamoId = 1,
                Monto = 1760000,
                FechaInicio = new DateTime(2023, 04, 19),
                FechaFin = new DateTime(2024, 04, 19),
                Interes = 15
            };



            /*var prestamo1 = (from d in _context.Prestamos
                            where d.Usuario.Cedula == cliente.Cedula
                            select new Prestamo{
                            
                                PrestamoId=d.PrestamoId,
                                Monto = d.Monto,
                                FechaInicio=d.FechaInicio,
                                FechaFin = d.FechaFin,
                                Tipo=d.Tipo,
                                Interes=d.Interes
                            
                            }).FirstOrDefault();*/

            ViewBag.Monto = prestamo.Monto;
            ViewBag.Meses = (prestamo.FechaFin.Month - prestamo.FechaInicio.Month) + 12 * (prestamo.FechaFin.Year - prestamo.FechaInicio.Year);
            ViewBag.Interes = prestamo.Interes / 100;
            ViewBag.TEM = Math.Pow(1 + ViewBag.Interes, 1.0 / 12) - 1.0;
            ViewBag.TEMPCT = ViewBag.TEM * 100;
            return View(prestamo);
        }

        public IActionResult LoansReportShow()
        {

            Prestamo prestamodb = new Prestamo();
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Loans/LoansReport";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects=
                {
                    new ObjectSettings()
                    {
                        Page = urlpage
                    }
                }

            };

            var pdffile = _converter.Convert(pdf);
            return File(pdffile,"application/pdf");
        }
        public IActionResult LoansReportDownload()
        {
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Loans/LoansReport";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        Page = urlpage
                    }
    }

            };

         

            var pdffile = _converter.Convert(pdf);
            string pdfname = "Loan_" + DateTime.Now.ToShortDateString() + ".pdf";
            return File(pdffile, "application/pdf",pdfname);
        }
        //En fecha planificado dejenlo igual que fechaInicio
        public IActionResult LoansFee()
        {
            CuotaPrestamo cprestamo = new CuotaPrestamo()
            {
                CuotaPrestamoID = 1,
                Monto = 1760000,
                FechaPlanificado = new DateTime(2023, 04, 19),
                FechaRealizado = DateTime.Now,
                ModalidadPago = "Cheque",
                Codigo = new Guid(),

                Prestamo = new Prestamo()
                {
                    PrestamoId = 1,
                    Monto = 1760000,
                    FechaInicio = new DateTime(2023, 04, 19),
                    FechaFin = new DateTime(2024, 04, 19),
                    Interes = 15
                }
            };

            ViewBag.Monto = cprestamo.Monto;
            ViewBag.Meses = (cprestamo.Prestamo.FechaFin.Month - cprestamo.Prestamo.FechaInicio.Month) + 12 * (cprestamo.Prestamo.FechaFin.Year -cprestamo.Prestamo.FechaInicio.Year);
            ViewBag.Interes = cprestamo.Prestamo.Interes / 100;
            ViewBag.TEM = Math.Pow(1 + ViewBag.Interes, 1.0 / 12) - 1.0;
            ViewBag.TEMPCT = ViewBag.TEM * 100;
            return View(cprestamo);
        }
        public IActionResult LoansFeeShow()
        {
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Loans/LoansFee";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        Page = urlpage
                    }
                }

            };

            var pdffile = _converter.Convert(pdf);
            return File(pdffile, "application/pdf");

        }
        public IActionResult LoansFeeDownload()
        {
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Loans/LoansFee";

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        Page = urlpage
                    }
                }

            };

            var pdffile = _converter.Convert(pdf);
            string pdfname = "LoanFee_" + DateTime.Now.ToShortDateString() + ".pdf";
            return File(pdffile, "application/pdf", pdfname);
        }

        public IActionResult Usuario(Cliente user)
        {
            cliente = user;
            return RedirectToAction("Loans");
        }


    }

}