using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cms.web.Models
{
    public class UserModel : BaseModel
    {
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Profile { get; set; }

        [Required]
        public bool IsAdmin { get; set; } = false;

        public PhoneModel Phone { get; set; }

        public AddressModel Address { get; set; }
    }
}
