using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class MenuModel : AuditoryBaseModel
    {
        [Required]
        public bool Secure { get; set; } = false;

        [Required]
        public string Role { get; set; } = "";

        [Required]
        public bool OnlyAdmin { get; set; } = false;

        [Required]
        public string Title { get; set; }

        [Required]
        public string Source { get; set; }

        public MenuSourceType SourceType { get; set; } = MenuSourceType.InternalPage;

        public MenuModel ParentMenu { get; set; }

        public bool Enabled { get; set; } = true;

        public int Position { get; set; } = 1;
    }

    public enum MenuSourceType
    {
        InternalPage = 1,
        ExternalPage = 2
    }

}
