using cms.web.Models;
using cms.web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public class MenuService
    {
        protected IRepository<MenuModel> _repository = null;

        public MenuService() => _repository = new MenuRepository();

        public List<MenuModel> GetAll()
        {
            return _repository.GetAll().OrderBy(l => l.ParentMenu == null).OrderBy(m=>m.Position).ToList();
        }

        public void Save(ref MenuModel model)
        {
            _repository.Save(ref model);
        }


    }
}
