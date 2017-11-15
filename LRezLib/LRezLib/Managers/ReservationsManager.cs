using LRezLib.Connections;
using LRezLib.DAO;
using LRezLib.Exceptions;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
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
            {
                bool toSendEmail = bool.Parse(ConfigurationManager.AppSettings["email_flag"]);
                if (toSendEmail)
                {
                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = ConfigurationManager.AppSettings["email_host"];
                    client.Port = int.Parse(ConfigurationManager.AppSettings["email_port"]);

                    // setup Smtp authentication
                    System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential(ConfigurationManager.AppSettings["email_add"], ConfigurationManager.AppSettings["email_pass"]);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(ConfigurationManager.AppSettings["email_add"]);
                    msg.To.Add(new MailAddress(r.Email));

                    msg.Subject = "Reservation Submitted";
                    msg.IsBodyHtml = true;

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html><head></head><body><b>Hi ");
                    sb.Append(r.Salutation + " " + r.Name + ",</b><br /><br />");
                    sb.Append("Thanks for your reservation with L'Rez. We will get in touch with you shortly. In the meanwhile, you may track your reservation with the tracking id: " + r.Tracking + ".<br /><br />");
                    sb.Append("Cheers, <br />");
                    sb.Append("L'Rez Training Restaurant");
                    sb.Append("</body>");

                    msg.Body = string.Format(sb.ToString());

                    try
                    {
                        client.Send(msg);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Send Email Fail: ID=" + r.ID + ", Email=" + r.Email);
                    }
                }

                return r;
            }
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
            bool result = ReservationsDAO.updateReservationStatus(id, status);
            if (result)
            {
                bool toSendEmail = bool.Parse(ConfigurationManager.AppSettings["email_flag"]);
                if (toSendEmail && (status == Constants.ReservationStatus_APPROVED || status == Constants.ReservationStatus_REJECTED || status == Constants.ReservationStatus_CANCELLED))
                {
                    Reservation r = ReservationsDAO.getReservation(id);

                    SmtpClient client = new SmtpClient();
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = ConfigurationManager.AppSettings["email_host"];
                    client.Port = int.Parse(ConfigurationManager.AppSettings["email_port"]);

                    // setup Smtp authentication
                    System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential(ConfigurationManager.AppSettings["email_add"], ConfigurationManager.AppSettings["email_pass"]);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(ConfigurationManager.AppSettings["email_add"]);
                    msg.To.Add(new MailAddress(r.Email));

                    msg.IsBodyHtml = true;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html><head></head><body><b>Hi ");
                    sb.Append(r.Salutation + " " + r.Name + ",</b><br /><br />");
                    sb.Append("Thanks for your reservation with L'Rez. ");
                    sb.Append("Your reservation on " + r.ReservationDateTime.ToString("dd-MMM-yyyy HH:mm") + " is ");

                    switch (status)
                    {
                        case Constants.ReservationStatus_APPROVED:
                            msg.Subject = "Reservation Approved";
                            sb.Append("APPROVED.");
                            break;
                        case Constants.ReservationStatus_REJECTED:
                            msg.Subject = "Reservation Declined";
                            sb.Append("DECLINED.");
                            break;
                        case Constants.ReservationStatus_CANCELLED:
                            msg.Subject = "Reservation Cancelled";
                            sb.Append("CANCELLED.");
                            break;
                        default: break;
                    }

                    sb.Append("You may track your reservation with the tracking id: " + r.Tracking + ".< br />< br /> ");
                    sb.Append("Cheers, <br />");
                    sb.Append("L'Rez Training Restaurant");
                    sb.Append("</body>");

                    msg.Body = string.Format(sb.ToString());

                    try
                    {
                        client.Send(msg);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Send Email Fail: ID=" + r.ID + ", Email=" + r.Email);
                    }
                }
            }

            return result;
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
