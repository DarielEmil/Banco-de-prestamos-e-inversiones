using Microsoft.AspNetCore.Mvc;

namespace CoopDEJC.Controllers
{
    public class LoansController : Controller
    {
        public IActionResult Loans()
        {
            return View();
        }
    }
}
