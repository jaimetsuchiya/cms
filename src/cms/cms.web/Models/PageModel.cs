using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class PageModel: AuditoryBaseModel
    {
        public MenuModel Menu { get; set; }

        public Guid? MenuId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public string MainCSS { get; set; }

        public string SectionCSS { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string Scripts { get; set; }

        [Required]
        public string FileName { get; set; }

        public DateTime? PublishedAt { get; set; }
    }
}
