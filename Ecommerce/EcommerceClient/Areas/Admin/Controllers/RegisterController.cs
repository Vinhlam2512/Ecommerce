using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Areas.Admin.Controllers {
    public class RegisterController : Controller {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
