using LRezLib;
using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LRezWebAppAdmin.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateReservation(Reservation reservation)
        {
            if (validateReservation(reservation))
            {
                Reservation r = ReservationsManager.createReservation(reservation);
                return Json(r);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Parameters");
            }
        }

        private bool validateReservation(Reservation reservation)
        {
            if (reservation.Name == null || reservation.Contact == null || reservation.ReservationDateTime == null)  //check for required fields
                return false;
            if (reservation.Name.Length == 0 || reservation.Contact.Length == 0)  //check for required fields
                return false;
            else if (reservation.ReservationDateTime < DateTime.Now.Date.AddDays(1))  //check for valid date
                return false;
            else if (reservation.NumVisitors < 1)  //check for valid number of visitors
                return false;
            else
                return true;
        }

        [HttpPost]
        public ActionResult TrackReservation(string tracking)
        {
            try
            {
                Reservation r = ReservationsManager.getReservation(tracking);
                TrackedReservation t = new TrackedReservation();
                t.ReservationDateTime = r.ReservationDateTime.ToString("f");
                if (Constants.HashReservationStatus.ContainsKey(r.Status))
                {
                    t.Status = Constants.HashReservationStatus[r.Status];
                    return Json(t);
                }
                else
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Invalid");

            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid");
            }
        }

        struct TrackedReservation
        {
            public string ReservationDateTime;
            public string Status;
        }

        public ActionResult Manage(string d, string w, string t)
        {
            DateTime daily = DateTime.Now;
            DateTime weekly = DateTime.Now;
            int tab = 0;

            if (d != null)
            {
                try
                {
                    daily = DateTime.Parse(d);
                }
                catch (Exception)
                {
                    daily = DateTime.Now;
                }
            }
            if (w != null)
            {
                try
                {
                    weekly = DateTime.Parse(w);
                }
                catch (Exception)
                {
                    weekly = DateTime.Now;
                }
            }
            if (t != null)
            {
                try
                {
                    tab = int.Parse(t);
                    if (tab < 0 || tab > 3)
                        tab = 0;
                }
                catch (Exception)
                {
                    tab = 0;
                }
            }

            List<Reservation> lstReservationsDaily = ReservationsManager.getReservations(daily);

            DateTime[] week = getWeek(weekly);
            List<Reservation> lstReservationWeekly = ReservationsManager.getReservations(week[0], week[1]);

            List<Reservation> lstPending = ReservationsManager.getReservations(Constants.ReservationStatus_PENDING, false);

            ViewBag.Daily = lstReservationsDaily;
            ViewBag.Weekly = lstReservationWeekly;
            ViewBag.Pending = lstPending;

            ViewBag.Day = daily.ToString("dd - MM - yyyy");
            ViewBag.Week = weekly.ToString("dd - MM - yyyy");
            ViewBag.WeekStart = week[0].ToString("dd - MM - yyyy");
            ViewBag.WeekEnd = week[1].AddDays(-1).ToString("dd - MM - yyyy");
            ViewBag.Tab = tab;

            return View();
        }

        private DateTime[] getWeek(DateTime date)
        {
            DateTime trimDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            int diff = trimDate.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
                diff += 7;
            DateTime startOfWeek = trimDate.AddDays(-1 * diff);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return new DateTime[2] { startOfWeek, endOfWeek };
        }

        public ActionResult UpdateReservationStatus(int id, int status)
        {
            if (ReservationsManager.updateReservationStatus(id, status))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }
    }
}