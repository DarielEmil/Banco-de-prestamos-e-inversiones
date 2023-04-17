using CoopDEJC.Models.CoopDBModels;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CoopDEJC.Controllers
{
    public class InvestmentController : Controller
    {
        private readonly IConverter _converter;
        public InvestmentController(IConverter converter)
        {
            _converter = converter;
        }
        public IActionResult Investment()
        {
            return View();
        }
        public IActionResult InvestmentReport()
        {
            Inversion inversion = new()
            {
                InversionID = 1,
                Monto = 20000,
                FechaInicio = new DateTime(2023, 04, 19),
                FechaFin = new DateTime(2024, 04, 19),
                Interes = 18
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
            urlpage = $"{urlpage}/InvestmentReport";

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
    }

}

