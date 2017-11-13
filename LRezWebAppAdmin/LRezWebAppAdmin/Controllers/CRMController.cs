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
    public class CRMController : Controller
    {
        // GET: CRM
        public ActionResult Index(string name, string contact)
        {
            if (contact != null)
            {
                ViewBag.contact = contact;
                ViewBag.profiles = CustomerProfilesManager.searchCustomerProfilesByContact(contact);

                ViewBag.suggestions = CustomerProfilesManager.searchSuggestionsByContact(contact);
            }
            else if (name != null)
            {
                ViewBag.name = name;
                ViewBag.profiles = CustomerProfilesManager.searchCustomerProfilesByName(name);

                ViewBag.suggestions = CustomerProfilesManager.searchSuggestionsByName(name);
            }

            return View();
        }

        public ActionResult CustomerProfile(string profile)
        {
            try
            {
                string[] months = new string[] {
                    "-",
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
                ViewBag.months = months;

                CustomerProfile customerProfile = CustomerProfilesManager.getCustomerProfile(profile);
                ViewBag.profile = customerProfile;

                List<CustomerEntry> customerInteractions = CustomerProfilesManager.getCustomerEntries(profile, Constants.CustomerEntryType_Interaction, 10);
                ViewBag.customerInteractions = customerInteractions;

                List<CustomerEntry> customerNotes = CustomerProfilesManager.getCustomerEntries(profile, Constants.CustomerEntryType_Note);
                ViewBag.customerNotes = customerNotes;

                List<Reservation> customerReservations = ReservationsManager.getReservations(profile);
                ViewBag.customerReservations = customerReservations;
            }
            catch (Exception)
            {
                ViewBag.error = "Profile not found";
                ViewBag.profile = new CustomerProfile();
            }

            return View();
        }

        [HttpPost]
        public ActionResult CustomerProfile(string profile, string entry, int entryType)
        {
            if (CustomerProfilesManager.addCustomerEntry(profile, entry, entryType, User.Identity.Name, DateTime.Now))
            {
                try
                {
                    string[] months = new string[] {
                    "-",
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
                    ViewBag.months = months;

                    CustomerProfile customerProfile = CustomerProfilesManager.getCustomerProfile(profile);
                    ViewBag.profile = customerProfile;

                    List<CustomerEntry> customerInteractions = CustomerProfilesManager.getCustomerEntries(profile, Constants.CustomerEntryType_Interaction, 10);
                    ViewBag.customerInteractions = customerInteractions;

                    List<CustomerEntry> customerNotes = CustomerProfilesManager.getCustomerEntries(profile, Constants.CustomerEntryType_Note);
                    ViewBag.customerNotes = customerNotes;

                    List<Reservation> customerReservations = ReservationsManager.getReservations(profile);
                    ViewBag.customerReservations = customerReservations;
                }
                catch (Exception)
                {
                    ViewBag.error = "Profile not found";
                    ViewBag.profile = new CustomerProfile();
                }
            }
            else
            {
                ViewBag.error = "Add Failed";
                ViewBag.profile = new CustomerProfile();
            }

            return View();
        }

        public ActionResult DeleteEntry(string profile, int entryType, int entryId)
        {
            CustomerProfilesManager.deleteEntry(entryId);

            return RedirectToAction("CustomerProfile", new { profile = profile });
        }

        public ActionResult updateProfileName(string contact, string name)
        {
            if (CustomerProfilesManager.updateProfileName(contact, name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }

        public ActionResult updateProfileEmail(string contact, string email)
        {
            if (CustomerProfilesManager.updateProfileEmail(contact, email))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }

        public ActionResult updateProfileDOB(string contact, int day, int month, int year)
        {
            if (CustomerProfilesManager.updateProfileDOB(contact, day, month, year))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Update Failed");
        }

        public ActionResult CreateProfile(string contact, string name, string email)
        {
            try
            {
                CustomerProfilesManager.createProfile(contact, name, email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return RedirectToAction("CustomerProfile", new { profile = contact });
        }

    }
}