using LRezLib;
using LRezLib.Exceptions;
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
    public class MenuController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Menu> menus = MenuManager.getMenus();
                return Ok(menus);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError(e);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(bool active)
        {
            try
            {
                List<Menu> menus;
                if (active)
                    menus = MenuManager.getMenus();
                else
                    menus = MenuManager.getMenus();
                return Ok(menus);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError(e);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Menu menu = MenuManager.getMenu(id);
                return Ok(menu);
            }
            catch (Exception_NotFound e)
            {
                Log.Error(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return InternalServerError(e);
            }
        }

    }
}
