using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cms.web.DTOs;
using cms.web.Infrastructure;
using cms.web.Models;
using cms.web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        private IPageService _pageService = null;
        private IMenuService _menuService = null;
        private ISettingsService _settingsService = null;

        public SettingsController(IViewRenderService viewRenderService, IPageService pageService, IMenuService menuService, ISettingsService settingsService, IHostingEnvironment hostingEnvironment) : base(viewRenderService, pageService, settingsService, hostingEnvironment) {
            _pageService = pageService;
            _menuService = menuService;
            _settingsService = settingsService;
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

            //Select all published pages
            //Call RePublish
            base.RePublishPages(_pageService.GetAll().Where(p => p.PublishedAt.HasValue).ToList());

            return settings;
        }

    }
}