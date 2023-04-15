﻿using CoopDEJC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoopDEJC.Controllers
{
    public class HomeController : Controller
    {
 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyProfile()
        {
            return View();
        }
        public IActionResult ManageAccount()
        {
            return View();
        }
        public IActionResult NewAccount()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}