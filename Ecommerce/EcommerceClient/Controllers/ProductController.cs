using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
