using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRezWebApp.Models
{
    public class Menu
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        public int Status { get; set; }

        public int Type { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public bool AllowBallot { get; set; }

        public string Remarks { get; set; }

        public Menu()
        {
            this.ID = -1;
            this.Name = "";
            this.Description = "";
            this.URL = "";
            this.Status = -1;
            this.Type = -1;
            this.LastModifiedBy = "";
            this.LastModifiedDate = DateTime.Now;
            this.AllowBallot = false;
            this.Remarks = "";
        }

        public Menu(string json)
        {
            JObject jObject = JObject.Parse(json);
            if (jObject["ID"] != null)
                ID = (int)jObject["ID"];
            if (jObject["Name"] != null)
                Name = (string)jObject["Name"];
            if (jObject["Description"] != null)
                Description = (string)jObject["Description"];
            if (jObject["URL"] != null)
                URL = (string)jObject["URL"];
            if (jObject["Status"] != null)
                Status = (int)jObject["Status"];
            if (jObject["Type"] != null)
                Type = (int)jObject["Type"];
            if (jObject["LastModifiedBy"] != null)
                LastModifiedBy = (string)jObject["LastModifiedBy"];
            if (jObject["LastModifiedDate"] != null)
                LastModifiedDate = DateTime.Parse((string)jObject["LastModifiedDate"]);
            if (jObject["AllowBallot"] != null)
                AllowBallot = (bool)jObject["AllowBallot"];
            if (jObject["Remarks"] != null)
                Remarks = (string)jObject["Remarks"];
        }

        public Menu(JToken jObject)
        {
            if (jObject["ID"] != null)
                ID = (int)jObject["ID"];
            if (jObject["Name"] != null)
                Name = (string)jObject["Name"];
            if (jObject["Description"] != null)
                Description = (string)jObject["Description"];
            if (jObject["URL"] != null)
                URL = (string)jObject["URL"];
            if (jObject["Status"] != null)
                Status = (int)jObject["Status"];
            if (jObject["Type"] != null)
                Type = (int)jObject["Type"];
            if (jObject["LastModifiedBy"] != null)
                LastModifiedBy = (string)jObject["LastModifiedBy"];
            if (jObject["LastModifiedDate"] != null)
                LastModifiedDate = (DateTime)jObject["LastModifiedDate"];
            if (jObject["AllowBallot"] != null)
                AllowBallot = (bool)jObject["AllowBallot"];
            if (jObject["Remarks"] != null)
                Remarks = (string)jObject["Remarks"];
        }

        public static List<Menu> ParseMenus(string json)
        {
            List<Menu> menus = new List<Menu>();

            JArray jArray = JArray.Parse(json);
            foreach (JToken jToken in jArray)
            {
                Menu m = new Menu(jToken);
                menus.Add(m);
            }

            return menus;
        }

        public static List<int> ParseMenuTypes(string json)
        {
            List<int> menuTypes = new List<int>();

            JArray jArray = JArray.Parse(json);
            foreach (JToken jToken in jArray)
            {
                menuTypes.Add(int.Parse(jToken.ToString()));
            }

            return menuTypes;
        }
    }
}