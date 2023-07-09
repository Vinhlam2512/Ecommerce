using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Areas.Admin.Controllers {
    [Area("Admin")]
    public class OrderController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
