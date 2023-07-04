using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface {
    public interface IRepository<T, K> where T : class {
        List<T> GetAll(params Expression<Func<T, object>>[] includes);
        List<T> Pagination(int page, int pageSize);
        T GetById(K id, params Expression<Func<T, object>>[] includes);
        T Delete(K id);
        T Update(T entity);
        T Create(T entity);
        T IsExist(K id);
    }
}
