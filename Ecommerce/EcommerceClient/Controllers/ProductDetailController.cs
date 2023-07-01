using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EcommerceClient.Controllers
{
    public class ProductDetailController : Controller
    {
		private readonly ILogger<ProductDetailController> _logger;

		private readonly HttpClient client = null;
		private string ApiUrl = "";

		public ProductDetailController(ILogger<ProductDetailController> logger)
		{
			_logger = logger;
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			ApiUrl = "https://localhost:7283/api/Product";
		}
		public IActionResult Index(int id)
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
