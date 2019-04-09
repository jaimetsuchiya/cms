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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cms.web.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private ISettingsService _settingsService = null;
        private IPageService _pageService = null;
        private IViewRenderService _viewRenderService = null;
        public BaseController(IViewRenderService viewRenderService, IPageService pageService, ISettingsService settingsService, IHostingEnvironment hostingEnvironment)
        {
            _pageService = pageService;
            _settingsService = settingsService;
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

        protected void PublishMenu(ref MenuModel menu)
        {
            var template = (menu.Layout == MenuLayout.SideBarMenu ? "" : "");
            //Load All Structure
            //Publish File
        }

        protected void RePublishPages(ref PageModel page)
        {
            //Generate new File
            //Update Published Date
            var dto = new PublishDTO();
            dto.Page = page;
            dto.Setttings = _settingsService.Get();

            var result = _viewRenderService.RenderToStringAsync("Pages/Template", dto).Result;
            if( string.IsNullOrEmpty(page.FileName) == false )
            {
                var fileName = Path.Combine(_hostingEnvironment.WebRootPath, page.FileName, ".html");
                if(System.IO.File.Exists(fileName))
                {
                    var fileNameVersionControl = fileName + "." + Guid.NewGuid().ToString("D");
                    System.IO.File.Move(fileName, fileNameVersionControl);
                }

                System.IO.File.WriteAllText(fileName, result);
            }
        }
    }

}
