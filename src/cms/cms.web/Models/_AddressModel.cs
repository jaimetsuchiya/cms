using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class AddressModel
    {
        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        [Required]
        public string AddressType { get; set; }

    }
}
