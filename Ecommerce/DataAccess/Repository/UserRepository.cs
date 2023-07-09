using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject;
using BusinessObject.Models;

using DataAccess.Interface;

namespace DataAccess.Repository {
    public class UserRepository : EntityRepository<User, int>, IUserRepository {
        public UserRepository(ShoesShopContext _dbContext) : base(_dbContext)
        {
        }

        public User Login(LoginModels loginModels)
        {
            try
            {
                using (var db = new ShoesShopContext())
                {
                    User? u = db.Users.FirstOrDefault(x => x.Username == loginModels.username && x.Password == loginModels.password);
                    if(u != null)
                    {
                        return u;
                    }
                    throw new Exception("User does not exist!");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
