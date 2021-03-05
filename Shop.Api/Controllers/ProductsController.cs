using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;
using System.Threading.Tasks;
using Shop.Api.Products.Queries;

namespace Shop.Api.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductListDTO>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }
 
    }
}