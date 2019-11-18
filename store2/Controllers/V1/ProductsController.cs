using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store2.Contracts.V1.Requests;
using store2.Contracts.V1.Responses;
using store2.Models;
using store2.Services;

namespace store2.Controllers.V1
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        [HttpGet("api/products")]
        public IActionResult GetAll()
        {

            var response = productsService.GetAll().Select(x => new ProductResponse { Id = x.Id, Name = x.Name });
            return Ok(response);
        }
        [HttpGet("api/products/{id}")]
        public IActionResult GetProduct([FromRoute]Guid id)
        {

            var product = productsService.GetProduct(id);
            if (product ==null)
            {
                return NotFound();
            }
            var response =  new ProductResponse { Id = product.Id, Name = product.Name };
            return Ok(response);
        }
        [HttpPost("api/products")]
        public IActionResult AddProduct([FromBody]productRequest productRequest)
        {
            var product = productsService.AddProduct(productRequest.Name);
            var response = new ProductResponse { Id = product.Id, Name = product.Name };
            return CreatedAtAction(nameof(GetProduct),new { id= response.Id},response);
        }
    }
}