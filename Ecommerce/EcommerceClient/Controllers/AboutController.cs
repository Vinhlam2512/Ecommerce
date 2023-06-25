using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
