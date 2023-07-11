using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetCurrentUserId()
		{
            var userId = HttpContext.User.FindFirstValue("sub");
            return Ok(userId);
		}
	}
}
