using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ColorController : ControllerBase
	{
		private readonly IColorRepository _colorRepo;

		public ColorController(IColorRepository colorRepository)
		{
			_colorRepo = colorRepository;
		}

		[HttpGet]
		public IActionResult GetColors()
		{
			try
			{
				var color = _colorRepo.GetAll();
				return Ok(color);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
