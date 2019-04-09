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
    public class MenusController : BaseController
    {
        private IMenuService _menuService = null;
        private IPageService _pageService = null;

        public MenusController(IViewRenderService viewRenderService, IPageService pageService, IMenuService menuService, ISettingsService settingsService, IHostingEnvironment hostingEnvironment) : base(viewRenderService, pageService, settingsService, hostingEnvironment) {
            _menuService = menuService;
            _pageService = pageService;
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

            //Select published pages using this menu
            //Call RePublish
            base.RePublishPages(_pageService.GetAll().Where(p => (p.SideMenuId.HasValue && p.SideMenuId == menu.Id) || (p.TopMenuId.HasValue && p.TopMenuId == menu.Id)).ToList());

            return menu;
        }

        /// <summary>
        /// Método chamado na publicação de uma página
        /// </summary>
        /// <param name="id"></param>
        /// <param name="publish"></param>
        /// <returns></returns>
        [HttpPut("{id}/{publish}")]
        public ActionResult<MenuModel> Put(Guid id, bool publish)
        {
            var model = _menuService.Get(id);
            if (model == null)
                return new NotFoundResult();

            else if (model.ParentMenuId.HasValue)
                return new BadRequestResult();

          
            return model;
        }

    }
}