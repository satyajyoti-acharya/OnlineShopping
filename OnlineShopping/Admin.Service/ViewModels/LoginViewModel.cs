using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string AdminId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
