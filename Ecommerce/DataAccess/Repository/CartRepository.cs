using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using DataAccess.Interface;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository {
    public class CartRepository : EntityRepository<Cart, int>, ICartRepository {
        public CartRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }

        public List<Cart> GetCartByUid(int uid)
        {
            var cart = GetAll();
            var carts = new List<Cart>();
			carts = dbContext.Carts.Include(x => x.Color).Include(x => x.Size).Where(x => x.UserId == uid).ToList();
            if (carts == null)
            {
                return new List<Cart>();
            }
            return carts;
		}

		public Cart IsCartExistByUid(int id, int uid)
		{
			try
			{
				Cart obj = dbContext.Carts.SingleOrDefault(x => x.Id == id && x.UserId == uid);
				if (obj == null)
				{
					throw new Exception();
				}
				else
				{
					return obj;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public Cart DeleteCart(int id, int uid)
		{
			try
			{
				Cart? obj = dbContext.Carts.SingleOrDefault(x => x.Id == id && x.UserId == uid);
				if (obj == null)
				{
					throw new Exception();
				}
				else
				{
					dbContext.Carts.Remove(obj);
					dbContext.SaveChanges();
					return obj;
				}
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
