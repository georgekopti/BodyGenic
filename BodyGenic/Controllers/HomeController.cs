using BodyGenic.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BodyGenic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LandingPage landingPageItems = new LandingPage();
            landingPageItems = (LandingPage)Session["landingPageItems"];
            return View(landingPageItems);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}