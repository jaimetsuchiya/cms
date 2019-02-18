using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms.web.Models;
using cms.web.Services;
using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    public class CMSController : Controller
    {
        private PageService _pageService = null;
        private MenuService _menuService = null;

        public CMSController() {
            _pageService = new PageService();
            _menuService = new MenuService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMenu(Guid? parentMenuId = null)
        {
            return Ok();
        }

        public IActionResult GetPages()
        {
            return Ok();
        }

        public IActionResult GetPageAreas(Guid pageId)
        {
            return Ok();
        }

        public IActionResult SavePage(PageModel model)
        {
            return Ok();
        }

    }
}