using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

namespace DataAccess.Interface {
    public interface IProductRepository : IRepository<Product, int> {
        int GetLastId();
        List<Product> SearchProduct(string? search, decimal? toPrice, decimal? fromPrice);
    }
}
