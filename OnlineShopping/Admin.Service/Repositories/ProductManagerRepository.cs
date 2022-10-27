using Admin.Service.EntityModels;
using Admin.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.Repositories
{
    public class ProductManagerRepository : IProductManagerRepository
    {
        OnlineShoppingContext onlineShoppingDBContext;
        public ProductManagerRepository(OnlineShoppingContext _onlineShoppingDBContext)
        {
            onlineShoppingDBContext = _onlineShoppingDBContext;
        }

        public bool AddProductDetails(ProductViewModel productDetails)
        {
            bool result = false;
            try
            {
                Product productDetail = new Product()
                {
                    ProductName = productDetails.ProductName,
                    ProductDesc = productDetails.ProductDesc,
                    Feature = productDetails.Feature,
                    Price = productDetails.Price,
                    QuantityAvailable = productDetails.QuantityAvailable


                };
                onlineShoppingDBContext.Products.Add(productDetail);
                onlineShoppingDBContext.SaveChanges();
                result = true;
                return result;
            }
            catch(Exception ex)
            {
                return false;
            }
                
        }

        //public bool UpdateProductStatus(string productName, int id)
        //{
        //    bool result = false;
        //    try
        //    {
        //        Product productDetail = new Product();

        //        if (onlineShoppingDBContext.Products.Any(x => x.Id == id && x.ProductName.ToLower() == productName.ToLower()))
        //        {
        //            var data = onlineShoppingDBContext.Products.Where(x => x.Id == id).FirstOrDefault();
        //            data.Status = "";
        //            onlineShoppingDBContext.Products.Update(data);
        //            onlineShoppingDBContext.SaveChanges();
        //            result = true;
        //        }

        //        return result;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}
        
        public bool DeleteProduct(string productName, int id)
        {
            bool result = false;
            try
            {
                Product productDetail = new Product();

                if (onlineShoppingDBContext.Products.Any(x => x.Id == id && x.ProductName.ToLower() == productName.ToLower()))
                {
                    var data = onlineShoppingDBContext.Products.Where(x => x.Id == id).FirstOrDefault();
                    onlineShoppingDBContext.Products.Remove(data);
                    onlineShoppingDBContext.SaveChanges();
                    result = true;
                }

                return result;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
