using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class MenuHistoryRepository: BaseRepository<MenuModel>, IRepository<MenuModel>
    {
        public MenuHistoryRepository() : base(Constants.History, "Menu", DateTime.Today)
        {
        }

    }
}
