using Admin.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.Repositories
{
    public interface IProductManagerRepository
    {
        public bool AddProductDetails(ProductViewModel productDetails);
        //public bool UpdateProductStatus(string productName, int id);
        public bool DeleteProduct(string productName, int id);
    }
}
