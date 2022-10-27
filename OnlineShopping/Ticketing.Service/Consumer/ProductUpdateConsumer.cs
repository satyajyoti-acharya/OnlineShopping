using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Shared.Model;
using Ticketing.Service.EntityModels;

namespace Ticketing.Service.Consumer
{
    public class ProductUpdateConsumer : IConsumer<Ticket>
    {
        
        //public ProductUpdateConsumer(OnlineShoppingContext _onlineShoppingDBContext)
        //{
        //    onlineShoppingDBContext = _onlineShoppingDBContext;
        //}
        public async Task Consume(ConsumeContext<Ticket> context)
        {
            var data = context.Message;
            UpdateProductStatus(data);
        }

        public void UpdateProductStatus(Ticket ticket)
        {
            OnlineShoppingContext onlineShoppingDBContext = new OnlineShoppingContext();
            Product productDetail = new Product();

            int orderedQuantity = onlineShoppingDBContext.Orders.Where(x => x.ProductId == ticket.id).Select(x => x.OrderQuantity).FirstOrDefault();
            if (onlineShoppingDBContext.Products.Any(x => x.Id == ticket.id && x.ProductName.ToLower() == ticket.productName.ToLower()))
            {
                var data = onlineShoppingDBContext.Products.Where(x => x.Id == ticket.id).FirstOrDefault();
                if (data.QuantityAvailable - orderedQuantity == 0)
                {
                    data.Status = "Out of Stock";
                }
                else if (data.QuantityAvailable - orderedQuantity <= 5)
                {
                    data.Status = "Hurry up to purchase";
                }
                else
                {
                    data.Status = "Product Available";
                }
                data.QuantityAvailable = data.QuantityAvailable - orderedQuantity;
                onlineShoppingDBContext.Products.Update(data);
                onlineShoppingDBContext.SaveChanges();
            }


        }
    }
    
}
