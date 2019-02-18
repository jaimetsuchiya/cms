using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class PageModel: AuditoryBaseModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string MetaData { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
