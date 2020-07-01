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
            Console.WriteLine(_entityFrameworkDbContext.ContextId.GetHashCode());
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
            if(list!=null&&list.Count>0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Add(item);
                }

                return _entityFrameworkDbContext.SaveChanges() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public async Task<bool> InsertAsync(IList<TEntity> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Add(item);
                }

                return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
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
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Update(item);
                }

                return _entityFrameworkDbContext.SaveChanges() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public async Task<bool> UpdateAsync(IList<TEntity> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Update(item);
                }

                return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public bool DeleteByID(object id)
        {
            var model = _entityFrameworkDbContext.Set<TEntity>().Find(id);
            _entityFrameworkDbContext.Set<TEntity>().Remove(model);
            return _entityFrameworkDbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteByIDAsync(object id)
        {
            var model = await _entityFrameworkDbContext.Set<TEntity>().FindAsync(id);
            _entityFrameworkDbContext.Set<TEntity>().Remove(model);
            return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
        }

        public bool DeleteByIds(object[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    var model = _entityFrameworkDbContext.Set<TEntity>().Find(id);
                    _entityFrameworkDbContext.Set<TEntity>().Remove(model);
                }

                return _entityFrameworkDbContext.SaveChanges() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public async Task<bool> DeleteByIdsAsync(object[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                foreach (var id in ids)
                {
                    var model = await _entityFrameworkDbContext.Set<TEntity>().FindAsync(id);
                    _entityFrameworkDbContext.Set<TEntity>().Remove(model);
                }

                return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
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
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Set<TEntity>().Remove(item);
                }

                return _entityFrameworkDbContext.SaveChanges() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public async Task<bool> DeleteAsync(IList<TEntity> list)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    _entityFrameworkDbContext.Set<TEntity>().Remove(item);
                }

                return await _entityFrameworkDbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NullReferenceException("参数不能为空！");
            }
        }

        public TEntity GetModel(object id)
        {
            return _entityFrameworkDbContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetModelAsync(object id)
        {
            return await _entityFrameworkDbContext.Set<TEntity>().FindAsync(id);
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
