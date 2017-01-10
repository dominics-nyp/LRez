using LRezLib.Connections;
using LRezLib.DAO;
using LRezLib.Exceptions;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Managers
{
    public class MenuManager
    {
        public static List<Menu> getMenus()
        {
            return MenuDAO.getMenus();
        }

        public static List<Menu> getMenus(int menuStatus)
        {
            return MenuDAO.getMenus(menuStatus);
        }

        public static List<Menu> getActiveMenus()
        {
            return MenuDAO.getMenus(Constants.MenuStatus_ACTIVE);
        }

        public static Menu getMenu(int id)
        {
            return MenuDAO.getMenu(id);
        }

        public static Menu createMenu(Menu menu)
        {
            Menu m = new Menu();
            m.Name = menu.Name;
            m.Description = menu.Description;
            m.URL = menu.URL;
            m.Status = menu.Status;
            m.LastModifiedBy = menu.LastModifiedBy;
            m.LastModifiedDate = DateTime.Now;
            m.Remarks = menu.Remarks;

            if (MenuDAO.addMenu(m))
                return m;
            else
                throw new Exception_Database("Unable to create new Menu");

        }
    }
}
