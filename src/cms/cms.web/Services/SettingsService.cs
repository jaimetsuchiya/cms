using cms.web.DTOs;
using cms.web.Models;
using cms.web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public class SettingsService
    {
        protected IRepository<SettingsModel> _repository = null;

        public SettingsService() => _repository = new SettingsRepository();

        public SettingsModel Get()
        {
            return _repository.GetAll().FirstOrDefault();
        }

        public void Save(ref SettingsModel model)
        {
            _repository.Save(ref model);
        }

        public bool IsAuthenticated(LogonDTO dto)
        {
            return true;
        }
    }
}
