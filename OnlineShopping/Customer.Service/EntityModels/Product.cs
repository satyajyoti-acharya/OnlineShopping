using System;
using System.Collections.Generic;

#nullable disable

namespace Customer.Service.EntityModels
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal Price { get; set; }
        public string Feature { get; set; }
        public string Status { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
