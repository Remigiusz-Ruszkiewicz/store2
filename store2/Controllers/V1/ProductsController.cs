using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store2.Contracts.V1;
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
        [HttpGet(ApiRoutes.Products.GetAll)]
        public async Task<IActionResult> GetAll()
        {

            var response = (await productsService.GetAllAsync()).Select(x => new ProductResponse { Id = x.Id, Name = x.Name });
            return Ok(response);
        }
        [HttpGet(ApiRoutes.Products.GetProduct)]
        public async Task<IActionResult> GetProduct([FromRoute]Guid id)
        {

            var product =await productsService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var response = new ProductResponse { Id = product.Id, Name = product.Name };
            return Ok(response);
        }
        [HttpPost(ApiRoutes.Products.AddProduct)]
        public async Task<IActionResult> AddProduct([FromBody]productRequest productRequest)
        {
            var product = await productsService.AddProductAsync(productRequest.Name);
            var response = new ProductResponse { Id = product.Id, Name = product.Name };
            return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
        }
        [HttpPut(ApiRoutes.Products.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid id , [FromBody]productRequest productRequest)
        {
            var product = await productsService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = productRequest.Name;
            var updateproduct = await productsService.UpdateAsync(product);
            var response = new ProductResponse { Id = updateproduct.Id, Name = updateproduct.Name };

            return Ok(response) ;
        }
        [HttpDelete(ApiRoutes.Products.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deleted = await productsService.DeleteAsync(id);
            if (deleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}