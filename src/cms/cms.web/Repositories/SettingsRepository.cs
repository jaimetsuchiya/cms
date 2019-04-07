using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public class SettingsRepository : BaseRepository<SettingsModel>, IRepository<SettingsModel>
    {
        public SettingsRepository() : base(Constants.CMS, "Settings")
        {
        }
    }
}
