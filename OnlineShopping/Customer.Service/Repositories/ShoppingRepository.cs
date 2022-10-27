using Customer.Service.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Repositories
{
    public class ShoppingRepository : IShoppingRepository
    {
        OnlineShoppingContext onlineShoppingDBContext;
        public ShoppingRepository(OnlineShoppingContext _onlineShoppingDBContext)
        {
            onlineShoppingDBContext = _onlineShoppingDBContext;
        }

        public List<Product> GetAllProducts()
        {
            return onlineShoppingDBContext.Products.ToList();
        }
        
        public List<Product> GetProduct(string productName)
        {
            List<Product> productSearch = new List<Product>();
            productSearch = onlineShoppingDBContext.Products.Where(x => x.ProductName.ToLower().Contains(productName.ToLower())).ToList();
            return productSearch;
        }
    }
}
