﻿using System;
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

        public Reservation(DataRow dr)
        {
            this.ID = (int)dr["ID"];
            if (dr["salutation"] != DBNull.Value)
                this.Salutation = (string)dr["salutation"];
            if (dr["name"] != DBNull.Value)
                this.Name = (string)dr["name"];
            if (dr["contact"] != DBNull.Value)
                this.Contact = (string)dr["contact"];
            if (dr["email"] != DBNull.Value)
                this.Email = (string)dr["email"];
            if (dr["reservation_datetime"] != DBNull.Value)
                this.ReservationDateTime = (DateTime)dr["reservation_datetime"];
            if (dr["num_visitors"] != DBNull.Value)
                this.NumVisitors = (int)dr["num_visitors"];
            if (dr["customer_type"] != DBNull.Value)
                this.CustomerType = (string)dr["customer_type"];
            if (dr["requests"] != DBNull.Value)
                this.Requests = (string)dr["requests"];
            if (dr["tracking"] != DBNull.Value)
                this.Tracking = (string)dr["tracking"];
            if (dr["social_account"] != DBNull.Value)
                this.SocialAccount = (string)dr["social_account"];
            if (dr["social_provider"] != DBNull.Value)
                this.SocialProvider = (string)dr["social_provider"];
            if (dr["status"] != DBNull.Value)
                this.Status = (int)dr["status"];
            if (dr["last_modified"] != DBNull.Value)
                this.LastModifiedBy = (string)dr["last_modified"];
            if (dr["last_modified_date"] != DBNull.Value)
                this.LastModifiedDate = (DateTime)dr["last_modified_date"];
            if (dr["remarks"] != DBNull.Value)
                this.Remarks = (string)dr["remarks"];
            if (dr["status_remarks"] != DBNull.Value)
                this.Status_Remarks = (string)dr["status_remarks"];
        }
    }
}
