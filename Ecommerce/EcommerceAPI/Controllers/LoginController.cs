using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IUserRepository _repoUser;

		public LoginController(IUserRepository repoUser)
		{
			_repoUser = repoUser;
		}

		[HttpPost]
		[Route("register")]
		public IActionResult Register(User user)
		{
			try
			{
				User register = _repoUser.Create(user);
				return Ok(register);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("login")]
		public IActionResult Login(User user)
		{
			try
			{
				using (var context = new ShoesShopContext())
				{
					User register = context.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
					if (register == null)
					{
						return NotFound();
					}
					return Ok(register);
				}
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
