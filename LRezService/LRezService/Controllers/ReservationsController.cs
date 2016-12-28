using LRezLib.Exceptions;
using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LRezService.Controllers
{
    public class ReservationsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Reservation> reservations = ReservationsManager.getReservations();
                return Ok(reservations);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(bool includeExpired)
        {
            try
            {
                List<Reservation> reservations = ReservationsManager.getReservations(includeExpired);
                return Ok(reservations);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(string tracking)
        {
            try
            {
                Reservation reservation = ReservationsManager.getReservation(tracking);
                return Ok(reservation);
            }
            catch (Exception_NotFound e)
            {
                Log.Error(e.Message);
                return BadRequest("Tracking: " + tracking + " not found");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Reservation reservation = ReservationsManager.getReservation(id);
                return Ok(reservation);
            }
            catch (Exception_NotFound e)
            {
                Log.Error(e.Message);
                return BadRequest("ID: " + id + " not found");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]Reservation reservation)
        {
            try
            {
                Reservation r = ReservationsManager.createReservation(reservation);
                return Ok(r);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }

    }
}
