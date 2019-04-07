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
        public MenuModel Menu { get; set; }


        [Required]
        public string Title { get; set; }


        [Required]
        public bool Public { get; set; }


        [Required]
        public string Content { get; set; }


        public string Description { get; set; }


        public string Keywords { get; set; }


        public string Scripts { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
