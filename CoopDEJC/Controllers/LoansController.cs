using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;
using CoopDEJC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using CoopDEJC.Models.CoopDBModels;
using System.Reflection;

namespace CoopDEJC.Controllers
{
    public class LoansController : Controller
    {
        private readonly IConverter _converter;
        public LoansController(IConverter converter)
        {
            _converter = converter;
        }
        public IActionResult Loans()
        {
            return View();
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
            ViewBag.Monto = prestamo.Monto;
            ViewBag.Meses = (prestamo.FechaFin.Month - prestamo.FechaInicio.Month) + 12 * (prestamo.FechaFin.Year - prestamo.FechaInicio.Year);
            ViewBag.Interes = prestamo.Interes / 100;
            ViewBag.TEM = Math.Pow(1 + ViewBag.Interes, 1.0 / 12) - 1.0;
            ViewBag.TEMPCT = ViewBag.TEM * 100;
            return View(prestamo);
        }
        public IActionResult LoansReportShow()
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



    }

}