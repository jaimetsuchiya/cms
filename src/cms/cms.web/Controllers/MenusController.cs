using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cms.web.DTOs;
using cms.web.Models;
using cms.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private MenuService _menuService = null;

        public MenusController() {
            _menuService = new MenuService();
        }


        [HttpGet]
        public ActionResult<IEnumerable<MenuModel>> Get()
        {
            return _menuService.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<MenuModel> Get(Guid id)
        {
            var model = _menuService.Get(id);
            if (model == null)
                return new NotFoundResult();
            return model;
        }


        [HttpPost()]
        public ActionResult<MenuModel> Post([FromBody] MenuModel menu)
        {
            _menuService.Save(ref menu);
            return menu;
        }

    }
}