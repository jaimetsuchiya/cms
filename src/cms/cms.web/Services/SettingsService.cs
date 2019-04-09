using cms.web.DTOs;
using cms.web.Models;
using cms.web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public interface ISettingsService
    {
        SettingsModel Get();
        void Save(ref SettingsModel model);
        bool IsAuthenticated(LogonDTO dto);
    }

    public class SettingsService: ISettingsService
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

            //TODO: Republica todas as páginas
        }

        public bool IsAuthenticated(LogonDTO dto)
        {
            return true;
        }
    }
}
