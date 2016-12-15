using LRezLib.Managers;
using LRezLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LRezService.Controllers
{
    public class ReservationsController : ApiController
    {
        public IEnumerable<Reservation> Get()
        {
            return ReservationsManager.getReservations();
        }


    }
}
