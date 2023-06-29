using BusinessObject.Models;
using DataAccess.Interface;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
				return Ok(_proRepo.GetAll());
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet]
		public IActionResult GetCategories()
		{
			try
			{
				return Ok(_cateRepo.GetAll());
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetProductById(int id)
		{
			try
			{
				Product product = _proRepo.GetById(id);
				if (product == null)
				{
					return NotFound();
				}
				return Ok(product);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public IActionResult AddProduct(Product product)
		{
			try
			{
				Product createProduct = _proRepo.Create(product);
				return Ok(createProduct);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateProduct(int id, Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			try
			{
				_proRepo.Update(product);
				return Ok();
			}
			catch
			{
				return BadRequest();
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
			catch
			{
				return BadRequest();
			}
		}
	}
}
