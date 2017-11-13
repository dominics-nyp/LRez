using LRezWebApp.Models;
using Microsoft.Security.Application;
using System.Configuration;
using System.Net;
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
            var client = new WebClient();
            var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/information");

            Information information = new Information(response);
            ViewBag.Text = Sanitizer.GetSafeHtmlFragment(information.AboutUsText);
            ViewBag.Image = information.AboutUsImage;

            return View();
        }

        public ActionResult Contact()
        {
            var client = new WebClient();
            var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/information");

            Information information = new Information(response);
            ViewBag.Text = Sanitizer.GetSafeHtmlFragment(information.ContactUsText);
            ViewBag.Map = information.ContactUsMap;

            return View();
        }
    }
}