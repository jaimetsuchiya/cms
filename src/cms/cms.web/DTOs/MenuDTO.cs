using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.DTOs
{
    public class MenuDTO
    {
		public string Title { get; set; }

        public string Source { get; set; }

        public List<MenuDTO> Childs { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
