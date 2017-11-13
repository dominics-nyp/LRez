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

        public static List<Reservation> getReservations(int reservationStatus, bool includeExpired = true)
        {
            return ReservationsDAO.getReservations(reservationStatus, includeExpired);
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

            r.Salutation = reservation.Salutation;
            r.Name = reservation.Name;
            r.Contact = reservation.Contact;
            r.Email = reservation.Email;
            r.ReservationDateTime = reservation.ReservationDateTime;
            r.NumVisitors = reservation.NumVisitors;
            r.CustomerType = reservation.CustomerType;
            r.Requests = reservation.Requests;
            r.Tracking = generateTracking(reservation.Name);
            r.SocialAccount = reservation.SocialAccount;
            r.SocialProvider = reservation.SocialProvider;
            r.Status = Constants.ReservationStatus_PENDING;
            r.LastModifiedBy = Constants.NEW;
            r.LastModifiedDate = DateTime.Now;
            r.Remarks = reservation.Remarks;

            if (ReservationsDAO.addReservation(r))
                return r;
            else
                throw new Exception_Database("Unable to create new Reservation");
        }

        private static string generateTracking(string name)
        {
            return Math.Abs((name + DateTime.Now.ToString()).GetHashCode()).ToString();
        }

        public static List<Reservation> getReservations(DateTime date)
        {
            return ReservationsDAO.getReservations(date);
        }

        public static List<Reservation> getReservations(DateTime fromDate, DateTime toDate)
        {
            return ReservationsDAO.getReservations(fromDate, toDate);
        }

        public static List<Reservation> getReservations(string contact)
        {
            return ReservationsDAO.getReservations(contact);
        }

        public static bool updateReservationStatus(int id, int status)
        {
            return ReservationsDAO.updateReservationStatus(id, status);
        }

        public static bool updateReservationRemarks(int id, string remarks)
        {
            return ReservationsDAO.updateReservationRemarks(id, remarks);
        }

        public static List<Reservation> searchReservations(string searchTerm, bool includeExpired = false)
        {
            return ReservationsDAO.searchReservations(searchTerm, includeExpired);
        }
    }
}
