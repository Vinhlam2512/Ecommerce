using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.Models;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interface {
    public class EntityRepository<T, K> : IRepository<T, K> where T : class {

        protected readonly ShoesShopContext dbContext;
        private readonly DbSet<T> dbSet;

        public EntityRepository(ShoesShopContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<T> Pagination(int page, int pageSize)
        {

            try
            {
                List<T> list = dbSet.ToList();

                int itemsToSkip = (page - 1) * pageSize;

                List<T> paginated = list.Skip(itemsToSkip).Take(pageSize).ToList();

                return paginated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Delete(K id)
        {
            try
            {
                T? obj = dbSet.Find(id);
                if(obj == null)
                {
                    throw new Exception($"{typeof(T).Name} with ID {id} does not exist!");
                }
                else
                {
                    dbSet.Remove(obj);
                    dbContext.SaveChanges();
                    return obj;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public T Create(T entity)
        {
            try
            {
                dbContext.Add(entity);
                dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public T GetById(K id)
        {
            try
            {
                T? obj = dbSet.Find(id);
                if(obj == null)
                {
                    throw new Exception($"{typeof(T).Name} with ID {id} does not exist!");
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public T Update(T entity)
        {
            try
            {
                var entityType = typeof(T);
                var idProperty = entityType.GetProperty("Id");
                if (idProperty == null)
                {
                    throw new Exception($"{entityType.Name} does not have an 'Id' property.");
                }
                var entityId = idProperty.GetValue(entity);
                T? obj = dbSet.Find(entityId);
                if(obj == null)
                {
                    throw new Exception($"{typeof(T).Name} with ID {entityId} does not exist!");
                }
                else
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public T IsExist(K id)
        {
            try
            {
                T? obj = dbSet.Find(id);
                if (obj == null)
                {
                    throw new Exception($"{typeof(T).Name} with ID {id} does not exist!");
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
