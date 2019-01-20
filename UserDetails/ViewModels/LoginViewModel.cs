using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserDetails.ViewModels
{
    public class LoginViewModel
    {
        [BindProperty]
        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [BindProperty]
        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
