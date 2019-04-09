using cms.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.DTOs
{
    public class PublishDTO
    {
        public SettingsModel Setttings { get; set; }

        public PageModel Page { get; set; }
    }
}
