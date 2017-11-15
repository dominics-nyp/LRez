using LRezLib;
using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LRezWebAppAdmin.Controllers
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

        public ActionResult Manage()
        {
            List<Menu> menus = MenuManager.getMenus();
            List<Menu> regular = new List<Menu>();
            List<Menu> celebrity = new List<Menu>();
            List<Menu> themed = new List<Menu>();
            List<Menu> degustation = new List<Menu>();

            foreach (Menu m in menus)
            {
                if (m.Status == 0 || m.Status == 1)
                {
                    switch (m.Type)
                    {
                        case Constants.MenuType_Regular:
                            regular.Add(m);
                            break;
                        case Constants.MenuType_Celebrity:
                            celebrity.Add(m);
                            break;
                        case Constants.MenuType_Themed:
                            themed.Add(m);
                            break;
                        case Constants.MenuType_Degustation:
                            degustation.Add(m);
                            break;
                        default:
                            break;
                    }
                }
            }

            ViewBag.Regular = regular;
            ViewBag.Celebrity = celebrity;
            ViewBag.Themed = themed;
            ViewBag.Degustation = degustation;

            return View();
        }

        [HttpPost]
        public ActionResult Manage(string title, HttpPostedFileBase file, int menuType)
        {
            string redirectHash = "";
            if (file != null && file.ContentLength > 0)
            {
                string[] _validExtensions = { ".jpg", ".jpeg", ".bmp", ".gif", ".png" };
                if (_validExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
                {
                    try
                    {
                        //string path = Path.Combine(ConfigurationManager.AppSettings["menu_dir"], Path.GetFileName(file.FileName));
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["menu_dir"]), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        Menu m = new Menu();
                        m.Name = title;
                        m.Description = "No Description Available";
                        m.URL = ConfigurationManager.AppSettings["menu_url"] + "/" + Path.GetFileName(file.FileName);
                        m.Status = Constants.MenuStatus_HIDDEN;
                        m.AllowBallot = false;
                        switch (menuType)
                        {
                            case 0:
                                m.Type = Constants.MenuType_Regular;
                                break;
                            case 1:
                                m.Type = Constants.MenuType_Celebrity;
                                redirectHash = "#celebrity";
                                break;
                            case 2:
                                m.Type = Constants.MenuType_Themed;
                                redirectHash = "#themed";
                                break;
                            case 3:
                                m.Type = Constants.MenuType_Degustation;
                                redirectHash = "#degustation";
                                break;
                            default:
                                m.Type = Constants.MenuType_Regular;
                                break;
                        }
                        m.LastModifiedBy = User.Identity.Name;
                        m.LastModifiedDate = DateTime.Now;

                        MenuManager.createMenu(m);

                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                else
                {
                    ViewBag.Message = "You have not specified a valid image file. Only .jpg, .jpeg, .bmp, .gif and .png are allowed.";
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            //return Manage();
            return new RedirectResult(Url.Action("Manage") + redirectHash);
        }

        public ActionResult UpdateMenuTitle(int id, string title)
        {
            if (MenuManager.updateMenuName(id, title, User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }

        public ActionResult UpdateMenuStatus(int id, int status)
        {
            if (MenuManager.updateMenuStatus(id, status, User.Identity.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }


        [ChildActionOnly]
        public ActionResult MenuBar()
        {
            List<int> model = MenuManager.getActiveMenuTypes();
            return View("_MenuPartial", null, model);
        }


    }
}