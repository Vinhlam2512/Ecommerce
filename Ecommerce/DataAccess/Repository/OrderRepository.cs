using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using DataAccess.Interface;

namespace DataAccess.Repository {
    public class OrderRepository : EntityRepository<Order, int>, IOrderRepository {
        public OrderRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }
    }
}
