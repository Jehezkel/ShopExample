using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Api.Products.Queries;
using Shop.Api.Products.Commands;

namespace Shop.Api.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductListDTO>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command){
            return await Mediator.Send(command);
        }
        

    }
}