﻿using LRezLib.Connections;
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
    class ReservationsDAO
    {
        public static List<Reservation> getReservations(bool includeExpired = false)
        {
            List<Reservation> reservations = new List<Reservation>();

            string sql = "select * from Reservations";

            if (includeExpired)
            {
                DataTable dt = DB.query(sql);
                foreach (DataRow dr in dt.Rows)
                    reservations.Add(new Reservation(dr));
            }
            else
            {
                sql += " where reservation_datetime>=@reservation_datetime";
                Parameter p = new Parameter("reservation_datetime", DateTime.Today);
                DataTable dt = DB.query(sql, p);
                foreach (DataRow dr in dt.Rows)
                    reservations.Add(new Reservation(dr));
            }

            return reservations;
        }

        public static List<Reservation> getReservations(string social_account, string social_provider, bool includeExpired = false)
        {
            List<Reservation> reservations = new List<Reservation>();

            if (social_account == null || social_provider == null)
                throw new Exception_InvalidParameters("Parameters [ social_account: " + social_account + " , social_provider: " + social_provider + " ] is invalid");

            else
            {
                List<Parameter> parameters = new List<Parameter>();
                string sql = "select * from Reservations where social_account=@social_account and social_provider=@social_provider";
                parameters.Add(new Parameter("@social_account", social_account));
                parameters.Add(new Parameter("@social_provider", social_provider));

                if (!includeExpired)
                {
                    sql += " and reservation_datetime>=@reservation_datetime";
                    parameters.Add(new Parameter("@reservation_datetime", DateTime.Today));
                }
                sql += " order by reservation_datetime desc";

                DataTable dt = DB.query(sql, parameters);

                foreach (DataRow dr in dt.Rows)
                    reservations.Add(new Reservation(dr));

                return reservations;
            }
        }

        public static Reservation getReservation(string tracking)
        {
            string sql = "select * from Reservations where tracking=@tracking order by reservation_datetime desc";
            Parameter parameter = new Parameter("@tracking", tracking);
            DataTable dt = DB.query(sql, parameter);

            if (dt.Rows.Count > 0)
            {
                Reservation r = new Reservation(dt.Rows[0]);
                return r;
            }
            else
                throw new Exception_NotFound("Reservation Tracking ID: [ " + tracking + " ] not found");
        }

        public static Reservation getReservation(int id)
        {
            string sql = "select * from Reservations where ID=@id";
            Parameter parameter = new Parameter("@id", id);
            DataTable dt = DB.query(sql, parameter);

            if (dt.Rows.Count > 0)
            {
                Reservation r = new Reservation(dt.Rows[0]);
                return r;
            }
            else
                throw new Exception_NotFound("Reservation ID: [ " + id + " ] not found");
        }

        public static bool addReservation(Reservation r)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Reservations (");
            sb.Append("name, contact, email, reservation_datetime, num_adults, num_children, ");
            sb.Append("requests, tracking, social_account, social_provider, status, last_modified, last_modified_date, remarks) ");
            sb.Append("values (");
            sb.Append("@name, @contact, @email, @reservation_datetime, @num_adults, @num_children, ");
            sb.Append("@requests, @tracking, @social_account, @social_provider, @status, @last_modified, @last_modified_date, @remarks)");

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@name", r.Name));
            parameters.Add(new Parameter("@contact", r.Contact));
            parameters.Add(new Parameter("@email", r.Email));
            parameters.Add(new Parameter("@reservation_datetime", r.ReservationDateTime));
            parameters.Add(new Parameter("@num_adults", r.NumAdults));
            parameters.Add(new Parameter("@num_children", r.NumChildren));

            if (r.Requests == null || r.Requests.Length == 0)
                parameters.Add(new Parameter("@requests", DBNull.Value));
            else
                parameters.Add(new Parameter("@requests", r.Requests));

            parameters.Add(new Parameter("@tracking", r.Tracking));

            if (r.SocialAccount == null || r.SocialAccount.Length == 0)
                parameters.Add(new Parameter("@social_account", DBNull.Value));
            else
                parameters.Add(new Parameter("@social_account", r.SocialAccount));

            if (r.SocialProvider == null || r.SocialProvider.Length == 0)
                parameters.Add(new Parameter("@social_provider", DBNull.Value));
            else
                parameters.Add(new Parameter("@social_provider", r.SocialProvider));

            parameters.Add(new Parameter("@status", r.Status));
            parameters.Add(new Parameter("@last_modified", r.LastModifiedBy));
            parameters.Add(new Parameter("@last_modified_date", r.LastModifiedDate));

            if (r.Remarks == null || r.Remarks.Length == 0)
                parameters.Add(new Parameter("@remarks", DBNull.Value));
            else
                parameters.Add(new Parameter("@remarks", r.Remarks));

            if (DB.execute(sb.ToString(), parameters) < 0)
                return false;
            else
                return true;
        }

    }
}
