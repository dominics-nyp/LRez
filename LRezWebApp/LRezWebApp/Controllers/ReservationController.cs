using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace LRezWebApp.Controllers
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

        public ActionResult TrackReservation()
        {
            return View();
        }

    }
}