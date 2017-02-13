using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Demo.Views.TestLab.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Controllers
{
    public class TestLabController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IActionResult Index()
        {
            Logger.Info("Index page says hello");
            return View();
        }

        public ViewResult LoginView()
        {
            return View();
        }

        public ViewResult Login()
        {
            ViewBag.ReturnUrl = "/";
            return View();
        }

        public ViewResult AllTagHelpers()
        {
            ViewBag.Countries = new List<TextValuModel>
            {
                new TextValuModel("UK","UK"),
                new TextValuModel("Australia","AU"),
                new TextValuModel("Newzeland","NZ"),
            };
            ViewBag.States = new List<SelectListItem>
            {
                new SelectListItem {Text = "Punjab", Value = "PB"},
                new SelectListItem {Text = "Haryana", Value = "HR"}
            };
            return View(new ContactModel());
        }

        public ViewResult AllHtmlHelpers()
        {
            return View(new ContactModel());
        }

        [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Any)]
        public string CachedString()
        {
            return "Your contact page." + DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        [HttpGet]
        [Route("all")]
        [Route("~/TestLab/AllUsers")]
        public IActionResult GetAllUsers()
        {
            return View("AllUsers");
        }
    }
}