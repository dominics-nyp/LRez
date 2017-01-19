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
        public static List<Menu> getMenus()
        {
            List<Menu> menus = new List<Menu>();
            string sql = "select * from Menu";

            DataTable dt = DB.query(sql);
            foreach (DataRow dr in dt.Rows)
                menus.Add(new Menu(dr));

            return menus;
        }

        public static List<Menu> getMenus(int menuStatus)
        {
            List<Menu> menus = new List<Menu>();
            string sql = "select * from Menu where status=@status";

            Parameter p = new Parameter("@status", menuStatus);
            DataTable dt = DB.query(sql, p);
            foreach (DataRow dr in dt.Rows)
                menus.Add(new Menu(dr));

            return menus;
        }

        public static List<Menu> getMenus(int menuStatus, int menuType)
        {
            List<Menu> menus = new List<Menu>();
            string sql = "select * from Menu where status=@status and type=@type";

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@status", menuStatus));
            parameters.Add(new Parameter("@type", menuType));

            DataTable dt = DB.query(sql, parameters);
            foreach (DataRow dr in dt.Rows)
                menus.Add(new Menu(dr));

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

        public static bool addMenu(Menu menu)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Menu (");
            sb.Append("name, description, url, status, type, last_modified, last_modified_date, remarks) ");
            sb.Append("values (");
            sb.Append("@name, @description, @url, @status, @type, @last_modified, @last_modified_date, @remarks)");

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@name", menu.Name));

            if (menu.Description == null || menu.Description.Length == 0)
                parameters.Add(new Parameter("@description", DBNull.Value));
            else
                parameters.Add(new Parameter("@description", menu.Description));

            parameters.Add(new Parameter("@url", menu.URL));
            parameters.Add(new Parameter("@status", menu.Status));
            parameters.Add(new Parameter("@type", menu.Type));
            parameters.Add(new Parameter("@last_modified", menu.LastModifiedBy));
            parameters.Add(new Parameter("@last_modified_date", menu.LastModifiedDate));

            if (menu.Remarks == null || menu.Remarks.Length==0)
                parameters.Add(new Parameter("@remarks", DBNull.Value));
            else
                parameters.Add(new Parameter("@remarks", menu.Remarks));

            if (DB.execute(sb.ToString(), parameters) < 0)
                return false;
            else
                return true;
        }

    }
}
