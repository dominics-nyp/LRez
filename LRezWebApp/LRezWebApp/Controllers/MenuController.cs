using LRezLib;
using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    int menuType = int.Parse(paramMenuType);
                    switch (menuType)
                    {
                        case Constants.MenuType_Regular:
                            ViewBag.MenuType = "Regular";
                            menus = MenuManager.getActiveMenus(menuType);
                            break;
                        case Constants.MenuType_Celebrity:
                            ViewBag.MenuType = "Celebrity";
                            menus = MenuManager.getActiveMenus(menuType);
                            break;
                        case Constants.MenuType_Themed:
                            ViewBag.MenuType = "Themed";
                            menus = MenuManager.getActiveMenus(menuType);
                            break;
                        case Constants.MenuType_Degustation:
                            ViewBag.MenuType = "Degustation";
                            menus = MenuManager.getActiveMenus(menuType);
                            break;
                        default:
                            ViewBag.MenuType = "All";
                            menus = MenuManager.getActiveMenus();
                            break;
                    }
                }
                catch (Exception)
                {
                    menus = MenuManager.getActiveMenus();
                }
            }
            else
                menus = MenuManager.getActiveMenus();

            return View(menus);
        }

        [ChildActionOnly]
        public ActionResult MenuBar()
        {
            List<int> model = MenuManager.getActiveMenuTypes();
            return View("_MenuPartial", null, model);
        }
    }
}