using LRezLib.Connections;
using LRezLib.DAO;
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

    }
}
