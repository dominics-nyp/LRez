using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Models
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

        public Menu(DataRow dr)
        {
            this.ID = (int)dr["ID"];
            if (dr["name"] != DBNull.Value)
                this.Name = (string)dr["name"];
            if (dr["description"] != DBNull.Value)
                this.Description = (string)dr["description"];
            if (dr["url"] != DBNull.Value)
                this.URL = (string)dr["url"];
            if (dr["status"] != DBNull.Value)
                this.Status = (int)dr["status"];
            if (dr["type"] != DBNull.Value)
                this.Type = (int)dr["type"];
            if (dr["last_modified"] != DBNull.Value)
                this.LastModifiedBy = (string)dr["last_modified"];
            if (dr["last_modified_date"] != DBNull.Value)
                this.LastModifiedDate = (DateTime)dr["last_modified_date"];
            if (dr["allow_ballot"] != DBNull.Value)
                this.AllowBallot = (bool)dr["allow_ballot"];
            if (dr["remarks"] != DBNull.Value)
                this.Remarks = (string)dr["remarks"];
        }
    }
}
