using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Areas.Admin.Controllers {
    public class LoginController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
