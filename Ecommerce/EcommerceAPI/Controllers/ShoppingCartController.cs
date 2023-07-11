using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static EcommerceAPI.Controllers.ProductController;

namespace EcommerceAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ShoppingCartController : ControllerBase
	{
		private readonly ICartRepository _cartRepo;

		public ShoppingCartController(ICartRepository cartRepository)
		{
			_cartRepo = cartRepository;
		}

		[HttpGet]
		public IActionResult GetCartsByUid()
		{
            var token = HttpContext.GetTokenAsync("Bearer", "access-token").Result;
            if (string.IsNullOrEmpty(token))
            {
				throw new Exception();
            }
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            int userId = Int32.Parse(decodedToken.Subject);

            try
            {
                List<Cart> cart = _cartRepo.GetCartByUid(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpGet]
		public IActionResult GetCartById(int id, int uId)
		{
			try
			{
				var c = _cartRepo.IsCartExistByUid(id, uId);
				return (IActionResult)c;
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		public class CartDTO
		{
			public int Id { get; set; }
			public int UserId { get; set; }
			public string ProductName { get; set; } = null!;
			public string Size { get; set; } = null!;
			public string Color { get; set; } = null!;
			public int Quantity { get; set; }
		}

		[HttpPost]
		public IActionResult AddCart(CartDTO cart)
		{
            var token = HttpContext.GetTokenAsync("Bearer", "access-token").Result;
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception();
            }
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            int userId = Int32.Parse(decodedToken.Subject);
            try
			{
				Cart c = _cartRepo.IsCartExistByUid(cart.Id, userId);
				if (c != null)
				{
					UpdateCart(cart.Id, cart);
				}
				else
				{
					c = new Cart()
					{
						Id = cart.Id,
						UserId = userId,
						ProductName = cart.ProductName,
						Size = cart.Size,
						Color = cart.Color,
						Quantity = cart.Quantity
					};
				}
				_cartRepo.Create(c);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCart(int id, CartDTO cart)
		{
			if (id != cart.Id)
			{
				throw new Exception();
			}
            var token = HttpContext.GetTokenAsync("Bearer", "access-token").Result;
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception();
            }
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            int userId = Int32.Parse(decodedToken.Subject);
            try
			{
				Cart c = _cartRepo.IsCartExistByUid(cart.Id, userId);
				if (c != null)
				{
					c = new Cart()
					{
						Id = cart.Id,
						UserId = userId,
						Quantity = cart.Quantity
					};
				}
				else
				{
					throw new Exception();
				}
				_cartRepo.Update(c);
				return Ok();

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCart(int id)
		{
            var token = HttpContext.GetTokenAsync("Bearer", "access-token").Result;
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception();
            }
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            int userId = Int32.Parse(decodedToken.Subject);
            try
			{
				Cart c = _cartRepo.IsCartExistByUid(id, userId);
				if (c == null)
				{
					return NotFound();
				}
				else
				{
					c = _cartRepo.DeleteCart(id, userId);
					return Ok(c);
				}

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
