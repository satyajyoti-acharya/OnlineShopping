using System;
using System.Collections.Generic;

#nullable disable

namespace Admin.Service.EntityModels
{
    public partial class CustomerLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int ContactNo { get; set; }
        public string UserRole { get; set; }
    }
}
