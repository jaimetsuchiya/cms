using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Services
{
    public interface ICRUDService<T>
    {
        List<T> GetAll();
        T Get(Guid id);
        void Save(ref T model);
    }
}
