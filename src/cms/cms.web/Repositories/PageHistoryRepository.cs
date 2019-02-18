using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class PageHistoryRepository : BaseRepository<PageModel>, IRepository<PageModel>
    {
        public PageHistoryRepository() : base(Constants.History, "Page", DateTime.Today)
        {
        }
    }
}
