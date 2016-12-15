using LRezLib.Connections;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRezLib.Managers
{
    public class ReservationsManager
    {
        public static List<Reservation> getReservations()
        {
            List<Reservation> reservations = new List<Reservation>();

            string sql = "select * from Reservations";
            DataTable dt = DB.query(sql);

            foreach (DataRow dr in dt.Rows)
                reservations.Add(new Reservation(dr));

            return reservations;

        }

        public static bool addReservation()
        {
            Reservation r = new Reservation();




            return false;
        }
    }
}
