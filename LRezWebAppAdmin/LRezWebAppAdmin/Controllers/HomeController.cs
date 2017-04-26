using LRezLib.Managers;
using LRezLib.Models;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LRezWebAppAdmin.Controllers
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

        [HttpPost]
        public ActionResult UpdateAboutText(string text)
        {
            if (InformationManager.updateAboutText(text))
            {
                string updated = InformationManager.getInformation().AboutUsText;
                return Json(new { text = updated });
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }

        [HttpPost]
        public ActionResult UpdateContactText(string text)
        {
            if (InformationManager.updateContactText(text))
            {
                string updated = InformationManager.getInformation().ContactUsText;
                return Json(new { text = updated });
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }
        
    }
}