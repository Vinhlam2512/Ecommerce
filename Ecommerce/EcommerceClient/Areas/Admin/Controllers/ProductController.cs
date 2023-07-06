using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace EcommerceClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public async Task<IActionResult> Index()
        {
            List<Product> products = await HttpClientWrapper.GetAsync<List<Product>>("api/Product/GetProducts");
            List<Category> categories = await HttpClientWrapper.GetAsync<List<Category>>("api/Product/GetCategories");
            ViewBag.Cate = categories;
            return View(products);
        }
    }
}
