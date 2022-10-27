using Customer.Service.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Repositories
{
    public interface IShoppingRepository
    {
        public List<Product> GetAllProducts();
        public List<Product> GetProduct(string productName);
    }
}
