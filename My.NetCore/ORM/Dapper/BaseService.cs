using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.ORM.Dapper
{
    public class BaseService<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(IList<TEntity> list)
        {
            throw new NotImplementedException();
        }
    }
}
