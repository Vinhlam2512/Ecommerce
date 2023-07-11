using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using DataAccess.Interface;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository {
    public class ProductRepository : EntityRepository<Product, int>, IProductRepository {
        public ProductRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }

        public int GetLastId()
        {
            int id = dbContext.Products.OrderByDescending(x => x.Id).FirstOrDefault().Id;
            return id;
        }

        public List<Product> SearchProduct(string? search, decimal? toPrice, decimal? fromPrice)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (var context = new ShoesShopContext())
                {
                    products = context.Products.ToList();
                    if (search != null)
                    {
                        products = products.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
                    }

                    if (toPrice != null)
                    {
                        products = products.Where(x => x.Price >= toPrice).ToList();
                    }

                    if (fromPrice != null)
                    {
                        products = products.Where(x => x.Price <= fromPrice).ToList();
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return products;
        }
    }
}
