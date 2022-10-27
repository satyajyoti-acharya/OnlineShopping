using Admin.Service.EntityModels;
using Admin.Service.Repositories;
using Admin.Service.ViewModels;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductManagementController : ControllerBase
    {
        IProductManagerRepository productManagerRepository;
        private readonly IBus bus;
        OnlineShoppingContext onlineShoppingDBContext;
        public ProductManagementController(IProductManagerRepository _productManagerRepository, IBus _bus, OnlineShoppingContext _onlineShoppingDBContext)
        {
            productManagerRepository = _productManagerRepository;
            bus = _bus;
            onlineShoppingDBContext = _onlineShoppingDBContext;
        }

        /// <summary>
        ///  Add product to inventory
        /// </summary>
        /// <param name="ProductViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProductDetails(ProductViewModel productDetails)
        {
            var result = productManagerRepository.AddProductDetails(productDetails);
            if (result)
            {
                return Ok("Product successfully added to inventory.");
            }
            else
            {
                return BadRequest("Invalid Input.");
            }



        }

        /// <summary>
        ///  Update product status
        /// </summary>
        /// <param name="ProductViewModel"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("update/{id}/{productName}")]
        public async Task<IActionResult> UpdateProductStatus(string productName, int id)
        {
            if (onlineShoppingDBContext.Products.Any(x => x.Id == id && x.ProductName.ToLower() == productName.ToLower()))
            {
                Ticket ticket = new Ticket();
                ticket.productName = productName;
                ticket.id = id;
                Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                await endpoint.Send(ticket);
                return Ok("Product status successfully updated.");
            }
            else
            {
                return BadRequest("Invalid Input.");
            }
        }



        


        /// <summary>
        ///  Delete Product
        /// </summary>
        /// <param name="ProductViewModel"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}/{productName}")]
        public IActionResult DeleteProduct(string productName, int id)
        {
            var result = productManagerRepository.DeleteProduct(productName, id);
            if (result)
            {
                return Ok("Product deleted successfully updated.");
            }
            else
            {
                return BadRequest("Invalid Input.");
            }



        }
    }
}
