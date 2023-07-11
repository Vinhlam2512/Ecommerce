using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace EcommerceClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<Product>? products = new List<Product>();
            try
            {
                products = await HttpClientWrapper.GetAsync<List<Product>>("/api/Product/GetProducts");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(products);
        }
    }
}
