using NoviInterviewMiniProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoviInterviewMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGlobalSettings _globalSettings;

        public HomeController(IGlobalSettings globalSettings)
        {
            _globalSettings = globalSettings;
        }
        public ActionResult Index()
        {
            ViewBag.ApiUrl = _globalSettings.ApiUrl;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}