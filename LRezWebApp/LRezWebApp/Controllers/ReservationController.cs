using LRezWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<ActionResult> CreateReservation(Reservation reservation)
        {
            if (validateReservation(reservation))
            {
                var client = new HttpClient();
                string baseUrl = ConfigurationManager.AppSettings.Get("LRezService");
                client.BaseAddress = new Uri(baseUrl);
                var stringContent = new StringContent(reservation.toJSON(), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("api/reservations", stringContent).Result;  // Blocking call!

                string responseString = await response.Content.ReadAsStringAsync();
                Reservation r = Reservation.parseReservation(responseString);
                return Json(r);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Invalid");
        }

        private bool validateReservation(Reservation reservation)
        {
            if (reservation.Name == null || reservation.Contact == null || reservation.Email == null || reservation.ReservationDateTime == null)  //check for required fields
                return false;
            if (reservation.Name.Length == 0 || reservation.Contact.Length == 0 || reservation.Email.Length == 0)  //check for required fields
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
                var client = new WebClient();
                client.QueryString.Add("tracking", tracking);
                var response = client.DownloadString(ConfigurationManager.AppSettings.Get("LRezService") + "api/reservations");
                Reservation r = Reservation.parseReservation(response);
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

        public struct TrackedReservation
        {
            public string ReservationDateTime;
            public string Status;
        }

        public ActionResult Ballot()
        {
            string paramMenu = this.Request.QueryString["menu"];
            int menuId = 0;
            if (int.TryParse(paramMenu, out menuId))
                ViewBag.menu = menuId;
            return View();
        }
    }
}