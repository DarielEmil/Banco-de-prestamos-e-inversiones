using Microsoft.AspNetCore.Mvc;

namespace CoopDEJC.Controllers
{
    public class InvestmentController : Controller
    {
        public IActionResult Investment()
        {
            return View();
        }
    }
}
