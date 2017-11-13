using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRezWebApp.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int NumVisitors { get; set; }
        public string CustomerType { get; set; }
        public string Requests { get; set; }
        public string Tracking { get; set; }
        public string SocialAccount { get; set; }
        public string SocialProvider { get; set; }
        public int Status { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Remarks { get; set; }
        public string Status_Remarks { get; set; }

        public Reservation()
        {
            this.ID = -1;
            this.Salutation = "";
            this.Name = "";
            this.Contact = "";
            this.Email = "";
            this.ReservationDateTime = DateTime.Now;
            this.NumVisitors = -1;
            this.CustomerType = "";
            this.Requests = "";
            this.Tracking = "";
            this.SocialAccount = "";
            this.SocialProvider = "";
            this.Status = -1;
            this.LastModifiedBy = "";
            this.LastModifiedDate = DateTime.Now;
            this.Remarks = "";
            this.Status_Remarks = "";
        }
        public Reservation(JObject jObject)
        {
            if (jObject["ID"] != null)
                ID = (int)jObject["ID"];
            if (jObject["Salutation"] != null)
                Salutation = (string)jObject["Salutation"];
            if (jObject["Name"] != null)
                Name = (string)jObject["Name"];
            if (jObject["Contact"] != null)
                Contact = (string)jObject["Contact"];
            if (jObject["Email"] != null)
                Email = (string)jObject["Email"];
            if (jObject["ReservationDateTime"] != null)
                ReservationDateTime = (DateTime)jObject["ReservationDateTime"];
            if (jObject["NumVisitors"] != null)
                NumVisitors = (int)jObject["NumVisitors"];
            if (jObject["CustomerType"] != null)
                CustomerType = (string)jObject["CustomerType"];
            if (jObject["Requests"] != null)
                Requests = (string)jObject["Requests"];
            if (jObject["Tracking"] != null)
                Tracking = (string)jObject["Tracking"];
            if (jObject["SocialAccount"] != null)
                SocialAccount = (string)jObject["SocialAccount"];
            if (jObject["SocialProvider"] != null)
                SocialProvider = (string)jObject["SocialProvider"];
            if (jObject["Status"] != null)
                Status = (int)jObject["Status"];
            if (jObject["LastModifiedBy"] != null)
                LastModifiedBy = (string)jObject["LastModifiedBy"];
            if (jObject["LastModifiedDate"] != null)
                LastModifiedDate = (DateTime)jObject["LastModifiedDate"];
            if (jObject["Remarks"] != null)
                Remarks = (string)jObject["Remarks"];
            if (jObject["Status_Remarks"] != null)
                Status_Remarks = (string)jObject["Status_Remarks"];
        }

        public string toJSON()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Reservation parseReservation(string json)
        {
            JObject jObject = JObject.Parse(json);
            Reservation reservation = new Reservation(jObject);

            return reservation;
        }

    }
}