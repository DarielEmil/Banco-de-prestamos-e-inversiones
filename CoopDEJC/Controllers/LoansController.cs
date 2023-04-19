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

namespace CoopDEJC.Controllers
{
    public class LoansController : Controller
    { 
        private readonly IConverter _converter;

        private readonly CoopContext _context;
        private Cliente? cliente;


       public LoansController(CoopContext context,IConverter converter)
        {
            _converter = converter;
            _context = context;
        }
        //Vista de prestamos
        public IActionResult Loans()
        {
            return View();
        }

        //Action que recibe los campos y los manda al DB
        public IActionResult LoansGet(int lamount,int lfee, DateTime ldate, DateTime lfeedate,int amount,int location,string id)
        {
            Prestamo prestamo = new Prestamo();
            

            prestamo.Monto = lamount;
            //Campo de interes
            prestamo.Interes = lfee;

            prestamo.FechaInicio = ldate;
            prestamo.FechaFin = lfeedate;
            prestamo.ValorGarantias = amount;
            //Es la ubicacion en de la garatia, no esta en la base de datos.
            prestamo.CuotasPagadas = location;
            

            var fiador = _context.Clientes.FirstOrDefault(f => f.Cedula == id);
            prestamo.Fiador= fiador;
            prestamo.Usuario = cliente;
            
            try
            {
                _context.Prestamos.Add(prestamo);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                Console.WriteLine("error al guardar: " + ex);
            }
            return RedirectToAction("Loans");
        }


        public IActionResult LoansReport()
        {


            var prestamo = (from d in _context.Prestamos
                            where d.Usuario.Cedula == cliente.Cedula
                            select new Prestamo{
                            
                                PrestamoId=d.PrestamoId,
                                Monto = d.Monto,
                                FechaInicio=d.FechaInicio,
                                FechaFin = d.FechaFin,
                                Tipo=d.Tipo,
                                Interes=d.Interes
                            
                            }).FirstOrDefault();;

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
            urlpage = $"{urlpage}/Loans/LoansReport{prestamodb}";

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
        //Actionresult que toma de cliente
        public IActionResult Usuario(Cliente user)
        {
            cliente = user;
            return RedirectToAction("Loans");
        }


    }

}