using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cms.web.DTOs;
using cms.web.Infrastructure;
using cms.web.Models;
using cms.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cms.web.Controllers
{
    public class BaseController : ControllerBase
    {
        private IPageService _pageService = null;
        private IViewRenderService _viewRenderService = null;
        public BaseController(IViewRenderService viewRenderService, IPageService pageService)
        {
            _pageService = pageService;
            _viewRenderService = viewRenderService;
        }

        protected void RePublishPages(List<PageModel> pages)
        {
            for( var i=0; i < pages.Count; i++)
            {
                var tmpPage = pages[i];
                RePublishPages(ref tmpPage);
            }
        }

        protected  void RePublishPages(ref PageModel page)
        {
            //Generate new File
            //Update Published Date
            var result = _viewRenderService.RenderToStringAsync("Email/Invite", null).Result;
        }
      

    }

}
