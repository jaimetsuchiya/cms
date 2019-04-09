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
    public class PagesController : BaseController
    {
        private IPageService _pageService = null;

        public PagesController(IViewRenderService viewRenderService, IPageService pageService): base(viewRenderService, pageService) {
            _pageService = pageService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<PageModel>> Get()
        {
            return _pageService.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<PageModel> Get(Guid id)
        {
            var model = _pageService.Get(id);
            if (model == null)
                return new NotFoundResult();
            return model;
        }


        [HttpPost()]
        public ActionResult<PageModel> Post([FromBody] PageModel page)
        {
            _pageService.Save(ref page);
            if (page.PublishedAt.HasValue )
                base.RePublishPages(ref page );

            return page;
        }

        /// <summary>
        /// Método chamado no save da página de edição de conteúdo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<PageModel> Put(Guid id, [FromBody] PageModel page)
        {
            if(id != Guid.Empty)
            {
                //Carrega os dados da página atual
                var model = _pageService.Get(id);
                if (model == null)
                    model = new PageModel();

                model.Content = page.Content;
                model.MainCSS = page.MainCSS;
                model.SectionCSS = page.SectionCSS;
                page = model;
            }

            _pageService.Save(ref page);

            if (page.PublishedAt.HasValue)
                base.RePublishPages(ref page );

            //TODO: If Page is Public, Generate new File
            return page;
        }

    }
}