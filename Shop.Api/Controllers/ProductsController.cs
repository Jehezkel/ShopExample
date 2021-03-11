using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Shop.Api.Products.Queries.GetProducts;
using Shop.Api.Products.Commands.CreateProduct;
using Shop.Api.Products.Queries.GetProductDetails;

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