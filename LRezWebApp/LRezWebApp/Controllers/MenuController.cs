using LRezWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LRezWebApp.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            List<Menu> menus;
            ViewBag.MenuType = "All";

            string paramMenuType = this.Request.QueryString["menutype"];
            if (paramMenuType != null)
            {
                try
                {
                    var client = new WebClient();
                    client.QueryString.Add("active", true.ToString());
                    client.QueryString.Add("menuType", paramMenuType);
                    var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/menu");
                    menus = Menu.ParseMenus(response);

                    int menuType = int.Parse(paramMenuType);
                    switch (menuType)
                    {
                        case Constants.MenuType_Regular:
                            ViewBag.MenuType = "Regular";
                            break;
                        case Constants.MenuType_Celebrity:
                            ViewBag.MenuType = "Celebrity";
                            break;
                        case Constants.MenuType_Themed:
                            ViewBag.MenuType = "Themed";
                            break;
                        case Constants.MenuType_Degustation:
                            ViewBag.MenuType = "Degustation";
                            break;
                        default:
                            ViewBag.MenuType = "All";
                            break;
                    }
                }
                catch (Exception e)
                { 
                    menus = new List<Menu>();
                }
            }
            else
            {
                var client = new WebClient();
                client.QueryString.Add("active", true.ToString());
                var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/menu");
                menus = Menu.ParseMenus(response);
            }

            return View(menus);
        }

        [ChildActionOnly]
        public ActionResult MenuBar()
        {
            var client = new WebClient();
            var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/menuType");
            List<int> model = Menu.ParseMenuTypes(response);
            return View("_MenuPartial", null, model);
        }
    }
}