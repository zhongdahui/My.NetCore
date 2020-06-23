using Microsoft.EntityFrameworkCore;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;
        private readonly DbSet<TEntity> _set;

        public BaseRepository(EntityFrameworkDbContext entityFrameworkDbContext)
        {
            if (_entityFrameworkDbContext == null) throw new ArgumentNullException(nameof(_entityFrameworkDbContext));
                _entityFrameworkDbContext = entityFrameworkDbContext;
            _set = _entityFrameworkDbContext.Set<TEntity>();
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _entityFrameworkDbContext.Remove(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Remove(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insert(TEntity entity)
        {
            _entityFrameworkDbContext.Add(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Insert(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Add(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda)
        {
            return _entityFrameworkDbContext.Set<TEntity>().Where(whereLambda);
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
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

        public async Task<bool> Update(TEntity entity)
        {
            _entityFrameworkDbContext.Update(entity);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(IList<TEntity> list)
        {
            _entityFrameworkDbContext.Update(list);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
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
