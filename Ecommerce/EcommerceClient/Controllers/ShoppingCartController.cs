using BusinessObject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EcommerceClient.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly ILogger<ShoppingCartController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly HttpClient client = null;

		public ShoppingCartController(ILogger<ShoppingCartController> logger, UserManager<ApplicationUser> userManager)
		{
			_logger = logger;
			_userManager = userManager;
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
		}
		public async Task<IActionResult> Index()
		{
			List<Cart> listCart = new List<Cart>();
			try
			{
				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					int id = Int32.Parse(user.Id);
					listCart = await HttpClientWrapper.GetAsync<List<Cart>>("/api/ShoppingCart/GetCartsByUid/" + id);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return View(listCart);
		}


	}
}
