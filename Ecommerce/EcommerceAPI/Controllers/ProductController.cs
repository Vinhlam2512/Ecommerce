using BusinessObject.Models;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static System.Net.Mime.MediaTypeNames;

namespace EcommerceAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _proRepo;
		private readonly ICategoryRepository _cateRepo;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_proRepo = productRepository;
			_cateRepo = categoryRepository;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{
			try
			{
				return Ok(_proRepo.GetAll(x => x.Category));
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public IActionResult GetCategories()
		{
			try
			{
				return Ok(_cateRepo.GetAll());
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetProductById(int id)
		{
			try
			{
				Product product = _proRepo.GetById(id, x => x.Category);
				if (product == null)
				{
					throw new NullReferenceException($"Cant find product with {id}!");
				}
				return Ok(product);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		public class ProductPost
        {
			public int Id { get; set; }
			public string Name { get; set; } = null!;
			public string Description { get; set; } = null!;
			public decimal Price { get; set; }
			public string Image { get; set; } = null!;
			public int CategoryId { get; set; }
            public string extension { get; set; }
        }

		[HttpPost]
		public IActionResult AddProduct(ProductPost product)
		{
			try
			{
				if (string.IsNullOrEmpty(product.Image))
				{
					throw new Exception("No image file uploaded.");
				}

				// Decode the base64 image data
				string base64Data = product.Image.Split(',')[1];
				byte[] imageData = Convert.FromBase64String(base64Data);

				// Generate a unique file name for the image
				int id = _proRepo.GetLastId();
				string nameOfImg = $"Product{id + 1}.{product.extension}";

				// Construct the file path
				string filePath = Path.Combine(Directory.GetCurrentDirectory(),"..", "EcommerceClient", "wwwroot", "imgProduct", nameOfImg);

				// Save the image file
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					stream.Write(imageData, 0, imageData.Length);
				}

				Product p = new Product()
				{
					Id = product.Id,
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					Image = nameOfImg,
					CategoryId = product.CategoryId
				};

				// Continue with the rest of your code
				Product createProduct = _proRepo.Create(p);
				return Ok(createProduct);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		[HttpPost("{id}")]
		public IActionResult UpdateProduct(Product product)
		{
            

			try
			{
				Product p = _proRepo.IsExist(product.Id);
				if(p == null)
                {
					throw new NullReferenceException($"Product does not exist!");
                }

				_proRepo.Update(product);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			try
			{
				_proRepo.Delete(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
