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
    public class SettingsController : ControllerBase
    {
        private PageService _pageService = null;
        private MenuService _menuService = null;
        private SettingsService _settingsService = null;

        public SettingsController() {
            _pageService = new PageService();
            _menuService = new MenuService();
            _settingsService = new SettingsService();
        }


        // GET api/values/5
        [HttpGet()]
        public ActionResult<SettingsModel> Get()
        {
            var model = _settingsService.Get();
            if (model == null)
                return new NotFoundResult();
            return model;
        }

        // PUT api/values/5
        [HttpPut()]
        public ActionResult<SettingsModel> Put([FromBody] SettingsModel settings)
        {
            _settingsService.Save(ref settings);
            return settings;
        }

    }
}