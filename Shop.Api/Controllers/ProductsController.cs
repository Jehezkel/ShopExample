using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Api.Products.Queries.GetProducts;
using Shop.Api.Products.Commands.CreateProduct;
using Shop.Api.Products.Queries.GetProductDetails;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListDTO>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductDetail(int id)
        {
            return await Mediator.Send(new GetProductDetailsQuery
            {
                ProductId = id
            });
        }


    }
}