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
    public class PagesController : ControllerBase
    {
        private PageService _pageService = null;
        private SettingsService _settingsService = null;

        public PagesController() {
            _pageService = new PageService();
            _settingsService = new SettingsService();
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
            //TODO: If Page is Public, Generate new File

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

            //TODO: If Page is Public, Generate new File
            return page;
        }

    }
}