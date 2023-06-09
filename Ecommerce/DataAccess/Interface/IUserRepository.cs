﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject;
using BusinessObject.Models;

namespace DataAccess.Interface {
    public interface IUserRepository : IRepository<User, int> {
        User Login(LoginModels loginModels);
    }
}
