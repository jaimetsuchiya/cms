using cms.web.Models;
using cms.web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public class PageService : ICRUDService<PageModel>
    {
        protected IRepository<PageModel> _repository = null;

        public PageService() => _repository = new PageRepository();

        public List<PageModel> GetAll()
        {
            return _repository.GetAll().OrderBy(l => l.Title).ToList();
        }

        public PageModel Get(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public void Save(ref PageModel model)
        {
            _repository.Save(ref model);
        }
    }
}
