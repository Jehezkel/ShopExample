using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Models;

namespace Shop.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        [Route("google-login/{token}")]
        [HttpPost]
        public async Task<ActionResult<AppUser>> SetUserToken([FromRoute] string token)
        {
            var googleUser = await 
            return Ok();
        }
    }
}