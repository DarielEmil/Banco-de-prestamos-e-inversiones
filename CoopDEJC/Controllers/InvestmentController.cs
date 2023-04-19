using CoopDEJC.Models;
using CoopDEJC.Models.CoopDBModels;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Cliente = CoopDEJC.Models.CoopDBModels.Cliente;
using Inversion = CoopDEJC.Models.CoopDBModels.Inversion;

namespace CoopDEJC.Controllers
{
    public class InvestmentController : Controller
    {
        private readonly IConverter _converter;
        private readonly CoopContext _context;
        private Cliente? cliente;
        public InvestmentController(IConverter converter,CoopContext context)
        {
            _converter = converter;
            _context = context;
        }
        public IActionResult Investment()
        {
            return View();
        }

        public IActionResult InvesmentGet(int iamount,int ifee,DateTime idate, DateTime ifeedate)
        {
            Console.WriteLine("klk");
            Inversion investment = new Inversion();
            investment.Monto= iamount;
            //campo de interes que depende
            investment.Interes = ifee;

            investment.FechaInicio = idate;
            investment.FechaInicio = ifeedate;

            investment.Usuario = cliente;

            foreach(var cuenta in cliente.Cuentas)
            {
                if(cuenta.activa = true)
                {
                    investment.Cuenta = cuenta;
    }
}
            try
            {
                _context.Inversiones.Add(investment);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine("error al guardar: " + ex);
            }
            return RedirectToAction("Investment");
        }



        public IActionResult InvestmentReport()
        {
            Inversion inversionDb = new Inversion();
            Inversion inversion = new()
            {
                InversionID = inversionDb.InversionID,
                Monto = inversionDb.Monto,
                FechaInicio = inversionDb.FechaInicio,
                FechaFin = inversionDb.FechaFin,
                Interes = inversionDb.Interes
            };
            ViewBag.Monto = inversion.Monto;
            ViewBag.Meses = (inversion.FechaFin.Month - inversion.FechaInicio.Month) + 12 * (inversion.FechaFin.Year - inversion.FechaInicio.Year);
            ViewBag.Interes = inversion.Interes / 100;
            ViewBag.TEM = Math.Pow(1 + ViewBag.Interes, 1.0 / 12) - 1.0;
            ViewBag.TEMPCT = ViewBag.TEM * 100;

            return View(inversion);
        }
        public IActionResult InvestementReportShow()
        {
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Investment/InvestmentReport";

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
        public IActionResult InvestmentReportDownload()
        {
            string actualpage = HttpContext.Request.Path;
            string urlpage = HttpContext.Request.GetEncodedUrl();
            urlpage = urlpage.Replace(actualpage, "");
            urlpage = $"{urlpage}/Investment/InvestmentReport";

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
            string pdfname = "Investment_" + DateTime.Now.ToShortDateString() + ".pdf";
            return File(pdffile, "application/pdf", pdfname);
        }
        //Recuerden que fecha planificado son las fechas que se encuentran en el cronograma
        public IActionResult InvestmentFee()
        {
            CuotaInversion cinversion = new CuotaInversion()
            {
                CuotaInversionID = 1,
                Monto = 1760000,
                FechaPlanificado = new DateTime(2023, 04, 19),
                FechaRealizado = DateTime.Now,
                Tipo = "Cheque",
                Codigo = new Guid(),

                Inversion = new Inversion()
                {
                    InversionID = 1,
                    Monto = 1760000,
                    FechaInicio = new DateTime(2023, 04, 19),
                    FechaFin = new DateTime(2024, 04, 19),
                    Interes = 15
                }
            };

            ViewBag.Monto = cinversion.Monto;
            ViewBag.Meses = (cinversion.Inversion.FechaFin.Month - cinversion.Inversion.FechaInicio.Month) + 12 * (cinversion.Inversion.FechaFin.Year - cinversion.Inversion.FechaInicio.Year);
            ViewBag.Interes = cinversion.Inversion.Interes / 100;
            ViewBag.TEM = Math.Pow(1 + ViewBag.Interes, 1.0 / 12) - 1.0;
            ViewBag.TEMPCT = ViewBag.TEM * 100;
            return View(cinversion);
        }

        public IActionResult Usuario(Cliente user)
        {
            cliente = user;
            return RedirectToAction("Investment");
        }


    }

}

