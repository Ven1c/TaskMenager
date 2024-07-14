using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Project.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserContoller:BaseController
    {
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }
    }
}
