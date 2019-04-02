using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; } = Guid.Empty;
    }


    public abstract class AuditoryBaseModel : BaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = "";

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; } = "";
    }


}
