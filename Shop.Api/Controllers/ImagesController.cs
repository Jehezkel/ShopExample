using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Images.Command;
using Shop.Api.Models;

namespace Shop.Api.Controllers
{
    public class ImagesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ProductImage>> Upload(IFormFile uploadedImage)
        {
            return await Mediator.Send(new UploadImageCommand
            {
                UploadedImage = uploadedImage
            });
        }
    }
}