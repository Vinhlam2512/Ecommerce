using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
