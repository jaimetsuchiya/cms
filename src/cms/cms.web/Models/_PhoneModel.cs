using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class PhoneModel
    {
        public PhoneModel()
        {
        }

        [Required]
        public string PhoneType { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Complement { get; set; }
    }
}
