using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class PageRepository : BaseRepository<PageModel>, IRepository<PageModel>
    {
        public PageRepository() : base(Constants.CMS, "Page")
        {
        }
    }
}
