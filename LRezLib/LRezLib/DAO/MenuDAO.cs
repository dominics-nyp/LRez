using LRezLib.Connections;
using LRezLib.Exceptions;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.DAO
{
    class MenuDAO
    {
        public static List<Menu> getMenus(List<int> menuStatus = null)
        {
            List<Menu> menus = new List<Menu>();
            string sql = "select * from Menu";

            if (menuStatus == null || menuStatus.Count == 0)
            {
                DataTable dt = DB.query(sql);
                foreach (DataRow dr in dt.Rows)
                    menus.Add(new Menu(dr));
            }
            else
            {
                sql += " where status in @status";
                Parameter p = new Parameter("@status", menuStatus);
                DataTable dt = DB.query(sql, p);
                foreach (DataRow dr in dt.Rows)
                    menus.Add(new Menu(dr));
            }

            return menus;
        }

        public static Menu getMenu(int id)
        {
            string sql = "select * from Menu where ID=@id";
            Parameter p = new Parameter("@id", id);
            DataTable dt = DB.query(sql, p);

            if (dt.Rows.Count > 0)
            {
                Menu menu = new Menu(dt.Rows[0]);
                return menu;
            }
            else
                throw new Exception_NotFound("Menu ID: [ " + id + " ] not found");
        }



    }
}
