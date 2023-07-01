using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EcommerceClient.Controllers
{
	public class LoginController : Controller
	{
		private readonly ILogger<LoginController> _logger;

		private readonly HttpClient client = null;
		private string ApiUrl = "";

		public LoginController(ILogger<LoginController> logger)
		{
			_logger = logger;
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			ApiUrl = "https://localhost:7283/api/Login";
		}

		[HttpPost]
		public IActionResult Index()
		{

			return View();
		}

		[HttpPost]		
		public IActionResult Register()
		{
			
			return View();
		}

	}
}
