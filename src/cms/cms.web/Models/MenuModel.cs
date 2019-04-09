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
        public string Title { get; set; }

        [Required]
        public string Source { get; set; }

        public MenuSourceType SourceType { get; set; } = MenuSourceType.InternalPage;

        public Guid? ParentMenuId { get; set; }

        public bool Enabled { get; set; } = true;

        public int Position { get; set; } = 1;

        [Required]
        public string Name { get; set; }

        [Required]
        public string CssClassName { get; set; }

        [Required]
        public MenuLayout Layout { get; set; }

        public DateTime? PublishedAt { get; set; }
    }

    public enum MenuSourceType
    {
        InternalPage = 1,
        ExternalPage = 2
    }

    public enum MenuLayout
    {
        SideBarMenu = 1,
        TopBarMenu = 2
    }
}
