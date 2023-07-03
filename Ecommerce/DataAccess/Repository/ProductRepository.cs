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
    }
}
