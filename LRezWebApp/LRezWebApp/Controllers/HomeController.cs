using LRezLib.Managers;
using LRezLib.Models;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LRezWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            Information information = InformationManager.getInformation();
            ViewBag.Text = Sanitizer.GetSafeHtmlFragment(information.AboutUsText);
            ViewBag.Image = information.AboutUsImage;

            return View();
        }

        public ActionResult Contact()
        {
            Information information = InformationManager.getInformation();
            ViewBag.Text = Sanitizer.GetSafeHtmlFragment(information.ContactUsText);
            ViewBag.Map = information.ContactUsMap;

            return View();
        }
    }
}