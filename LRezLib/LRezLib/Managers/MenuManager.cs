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
        public static List<Menu> getMenus(List<int> menuStatus = null)
        {
            return MenuDAO.getMenus(menuStatus);
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
