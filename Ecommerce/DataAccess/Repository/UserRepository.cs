using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using DataAccess.Interface;

namespace DataAccess.Repository {
    public class UserRepository : EntityRepository<User, int>, IUserRepository {
        public UserRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }
    }
}
