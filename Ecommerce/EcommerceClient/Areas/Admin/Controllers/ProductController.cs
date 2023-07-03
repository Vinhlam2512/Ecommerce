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

        // GET: Admin/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Image,CategoryId")] Product product)
        {
           
            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            return View();
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Image,CategoryId")] Product product)
        {
          
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           

            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            return RedirectToAction(nameof(Index));
        }

    }
}
