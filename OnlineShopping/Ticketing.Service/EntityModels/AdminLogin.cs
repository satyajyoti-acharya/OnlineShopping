using System;
using System.Collections.Generic;

#nullable disable

namespace Ticketing.Service.EntityModels
{
    public partial class AdminLogin
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
