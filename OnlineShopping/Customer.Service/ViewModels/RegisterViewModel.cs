﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int ContactNo { get; set; }
    }
}
