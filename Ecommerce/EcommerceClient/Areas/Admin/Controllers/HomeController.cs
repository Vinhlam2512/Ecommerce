using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Areas.Admin.Controllers {
    public class HomeController : Controller {
        public IActionResult Index2()
        {
            return View();
        }
    }
}
