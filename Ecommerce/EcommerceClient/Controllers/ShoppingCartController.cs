using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Controllers
{
	public class ShoppingCartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
