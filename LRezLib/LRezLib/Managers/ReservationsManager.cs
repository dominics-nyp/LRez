using LRezLib.Connections;
using LRezLib.DAO;
using LRezLib.Exceptions;
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
        public static List<Reservation> getReservations(bool includeExpired = false)
        {
            return ReservationsDAO.getReservations(includeExpired);
        }

        public static List<Reservation> getReservations(string social_account, string social_provider, bool includeExpired = false)
        {
            return ReservationsDAO.getReservations(social_account, social_provider, includeExpired);
        }

        public static Reservation getReservation(string tracking)
        {
            return ReservationsDAO.getReservation(tracking);
        }

        public static Reservation getReservation(int id)
        {
            return ReservationsDAO.getReservation(id);
        }

        public static Reservation createReservation(Reservation reservation)
        {
            Reservation r = new Reservation();

            r.Name = reservation.Name;
            r.Contact = reservation.Contact;
            r.Email = reservation.Email;
            r.ReservationDateTime = reservation.ReservationDateTime;
            r.NumAdults = reservation.NumAdults;
            r.NumChildren = reservation.NumChildren;
            r.Requests = reservation.Requests;
            r.Tracking = generateTracking(reservation.Name);
            r.SocialAccount = reservation.SocialAccount;
            r.SocialProvider = reservation.SocialProvider;
            r.Status = Constants.ReservationStatus_NEW;
            r.LastModifiedBy = "NEW";
            r.LastModifiedDate = DateTime.Now;
            r.Remarks = reservation.Remarks;

            if (ReservationsDAO.addReservation(r))
                return r;
            else
                throw new Exception_Database("Unable to create new Reservation");
        }

        private static string generateTracking(string name)
        {
            return (name + DateTime.Now.ToString()).GetHashCode().ToString();
        }

    }
}
