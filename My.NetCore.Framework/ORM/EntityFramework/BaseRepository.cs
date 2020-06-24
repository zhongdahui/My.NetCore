using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class BaseRepository<TEntity> : Transaction, IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;
        private readonly DbSet<TEntity> _set;

        public BaseRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        {
            if (entityFrameworkDbContext == null) throw new ArgumentNullException(nameof(entityFrameworkDbContext));
            _entityFrameworkDbContext = entityFrameworkDbContext;

            _set = _entityFrameworkDbContext.Set<TEntity>();
        }

        public bool Insert(TEntity entity)
        {
            _entityFrameworkDbContext.Add(entity);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            _entityFrameworkDbContext.Add(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool Insert(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Add(list);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> InsertAsync(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Add(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool Update(TEntity entity)
        {
            _entityFrameworkDbContext.Update(entity);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _entityFrameworkDbContext.Update(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool Update(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Update(list);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Update(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool DeleteByID(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIDAsync(object id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteByIdsAsync(object[] ids)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TEntity entity)
        {
            _entityFrameworkDbContext.Remove(entity);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _entityFrameworkDbContext.Remove(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool Delete(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Remove(list);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Remove(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda)
        {
            return _entityFrameworkDbContext.Set<TEntity>().Where(whereLambda);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            var list = _entityFrameworkDbContext.Set<TEntity>().Where(whereLambda);

            totalCount = list.Count();

            if (isAsc)
            {
                return list.OrderBy<TEntity, object>(orderLambda).Skip<TEntity>((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return list.OrderByDescending<TEntity, object>(orderLambda).Skip<TEntity>((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

        public IEnumerable<T> SqlQuery<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteCommand(string sql)
        {
            throw new NotImplementedException();
        }

        public int ExecuteScale(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
