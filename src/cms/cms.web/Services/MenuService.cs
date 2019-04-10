using cms.web.Models;
using cms.web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public interface IMenuService
    {
        List<MenuModel> GetAll();
        MenuModel Get(Guid id);
        void Save(ref MenuModel model);
    }

    public class MenuService: IMenuService
    {
        protected IRepository<MenuModel> _repository = null;

        public MenuService() => _repository = new MenuRepository();

        public List<MenuModel> GetAll()
        {
            return _repository.GetAll().OrderBy(l => l.ParentMenuId.HasValue == false).OrderBy(m=>m.Position).ToList();
        }

        public MenuModel Get(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public void Save(ref MenuModel model)
        {
            _repository.Save(ref model);
            //TODO: Republica todas as páginas que utilizam o menu afetado
        }

        public void GetTree(Guid id, ref List<MenuModel> menus)
        {
            if (menus == null)
                menus = new List<MenuModel>();

            var main = _repository.GetSingle(id);
            if( main != null )
            {
                if (main.ParentMenuId.HasValue)
                    menus.Add(main);

                var childs = _repository.GetAll().Where(m => m.ParentMenuId == main.Id).ToList();
                if( childs != null )
                {
                    for (var i = 0; i < childs.Count; i++)
                        GetTree(childs[i].Id, ref menus);
                }
                
            }
        }

    }
}
