using Microsoft.AspNetCore.Mvc;

namespace EcommerceClient.Areas.Admin.Controllers {
    public class DashBoardController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
