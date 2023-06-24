using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using DataAccess.Interface;

namespace DataAccess.Repository {
    public class CategoryRepository : EntityRepository<Category, int>, ICategoryRepository {
        public CategoryRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }
    }
}
