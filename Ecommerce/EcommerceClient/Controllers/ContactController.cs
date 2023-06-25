using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
