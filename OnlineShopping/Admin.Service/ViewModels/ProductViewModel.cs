using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.ViewModels
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public string Feature { get; set; }
        public string Status { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
