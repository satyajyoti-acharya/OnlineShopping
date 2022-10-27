using System;
using System.Collections.Generic;

#nullable disable

namespace Ticketing.Service.EntityModels
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int OrderQuantity { get; set; }
    }
}
