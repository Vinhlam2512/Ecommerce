using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface {
    public interface IRepository<T, K> where T : class {
        List<T> GetAll();
        List<T> Pagination(int page, int pageSize);
        T GetById(K id);
        T Delete(K id);
        T Update(T entity);
        T Create(T entity);
    }
}
