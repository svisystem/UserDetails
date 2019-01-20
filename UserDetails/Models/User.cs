using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.Models
{
    public class User
    {
        [DisplayName("")]
        public int? Id { get; set; }

        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("Firstname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Birth date")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [DisplayName("Birth place")]
        public string BirthPlace { get; set; }
    }
}
