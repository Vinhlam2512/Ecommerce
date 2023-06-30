using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;

namespace EcommerceClient.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

		private readonly HttpClient client = null;
		private string ApiUrl = "";

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			ApiUrl = "https://localhost:7283/api/Product";
		}

        public IActionResult Index()
        {
			HttpResponseMessage response = client.GetAsync(ApiUrl + "/GetProducts").Result;
			List<Product>? products = new List<Product>();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				products = response.Content.ReadFromJsonAsync<List<Product>>().Result;
			}

			return View(products);
        }

        public IActionResult Detail(int id)
		{
			HttpResponseMessage response = client.GetAsync(ApiUrl + "/GetProductById/" + id).Result;
			Product product = new Product();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				product = response.Content.ReadFromJsonAsync<Product>().Result;
			}

			return View(product);
		}

      
    }
}