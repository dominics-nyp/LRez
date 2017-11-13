using LRezLib.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LRezService.Controllers
{
    public class MenuTypeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<int> menuTypes = MenuManager.getActiveMenuTypes();
                return Ok(menuTypes);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError(e);
            }
        }
    }
}
