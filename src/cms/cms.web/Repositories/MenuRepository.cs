using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class MenuRepository: BaseRepository<MenuModel>, IRepository<MenuModel>
    {
        public MenuRepository() : base(Constants.CMS, "Menu")
        {

        }

        public List<MenuModel> GetChilds(Guid parentId)
        {
            return base.GetAll().OrderBy(l => l.ParentMenu != null && l.ParentMenu.Id == parentId).OrderBy(m => m.Position).ToList();
        }
    }
}
