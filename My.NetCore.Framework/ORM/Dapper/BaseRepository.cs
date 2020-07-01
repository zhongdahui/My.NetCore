using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.Dapper
{
    public class BaseRepository<TEntity> : Transaction, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public bool Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(IList<TEntity> list)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public TEntity GetModel(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetModelAsync(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            throw new NotImplementedException();
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
