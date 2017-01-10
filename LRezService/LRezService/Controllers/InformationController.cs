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
    public class InformationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                Information information = InformationManager.getInformation();
                return Ok(information);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError();
            }
        }
    }
}
