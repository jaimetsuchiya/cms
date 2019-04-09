using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cms.web.DTOs;
using cms.web.Infrastructure;
using cms.web.Models;
using cms.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : BaseController
    {
        private IMenuService _menuService = null;
        private IPageService _pageService = null;

        public MenusController(IViewRenderService viewRenderService, IPageService pageService, IMenuService menuService) : base(viewRenderService, pageService) {
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

    }
}