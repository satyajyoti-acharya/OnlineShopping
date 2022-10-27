using Customer.Service.EntityModels;
using Customer.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingController : ControllerBase
    {

        IShoppingRepository shoppingRepository;
        public ShoppingController(IShoppingRepository _shoppingRepository)
        {
            shoppingRepository = _shoppingRepository;
        }

        [HttpGet]
        [Route("All")]
        public List<Product>GetAllProducts()
        {
            var result = shoppingRepository.GetAllProducts();
            return result;
        }

        [HttpGet]
        [Route("product/search/{productName}")]
        public List<Product> GetProduct(string productName)
        {
            var result = shoppingRepository.GetProduct(productName);
            return result;
        }
    }
}
