using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetSingle(Guid id);
        List<T> GetAll();
        void Save(ref T model);
        void Delete(Guid id);
    }
}
