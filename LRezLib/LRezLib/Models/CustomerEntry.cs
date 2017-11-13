using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Models
{
    public class CustomerEntry
    {
        public int ID { get; set; }

        public string Contact { get; set; }

        public string Entry { get; set; }

        public int EntryType { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public CustomerEntry()
        {
            this.ID = -1;
            this.Contact = "";
            this.Entry = "";
            this.EntryType = -1;
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = "";
        }

        public CustomerEntry(DataRow dr)
        {
            this.ID = (int)dr["id"];
            if (dr["customer_contact"] != DBNull.Value)
                this.Contact = (string)dr["customer_contact"];
            if (dr["entry"] != DBNull.Value)
                this.Entry = (string)dr["entry"];
            if (dr["type"] != DBNull.Value)
                this.EntryType = (int)dr["type"];
            if (dr["created_date"] != DBNull.Value)
                this.CreatedDate = (DateTime)dr["created_date"];
            if (dr["created_by"] != DBNull.Value)
                this.CreatedBy = (string)dr["created_by"];
        }

    }
}
