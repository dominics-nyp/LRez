using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int NumAdults { get; set; }
        public int NumChildren { get; set; }
        public string Requests { get; set; }
        public string Tracking { get; set; }
        public string UserAccount { get; set; }
        public string Remarks { get; set; }

        public Reservation()
        {

        }

        public Reservation(DataRow dr)
        {
            this.ID = (int)dr["ID"];
            if (dr["name"] != DBNull.Value)
                this.Name = (string)dr["name"];
            if (dr["contact"] != DBNull.Value)
                this.Contact = (string)dr["contact"];
            if (dr["email"] != DBNull.Value)
                this.Email = (string)dr["email"];
            if (dr["reservationdatetime"] != DBNull.Value)
                this.ReservationDateTime = (DateTime)dr["reservationdatetime"];
            if (dr["numAdults"] != DBNull.Value)
                this.NumAdults = (int)dr["numAdults"];
            if (dr["numChildren"] != DBNull.Value)
                this.NumChildren = (int)dr["numChildren"];
            if (dr["requests"] != DBNull.Value)
                this.Requests = (string)dr["requests"];
            if (dr["tracking"] != DBNull.Value)
                this.Tracking = (string)dr["tracking"];
            if (dr["useraccount"] != DBNull.Value)
                this.UserAccount = (string)dr["useraccount"];
            if (dr["remarks"] != DBNull.Value)
                this.Remarks = (string)dr["remarks"];
        }
    }
}
