using My.NetCore.Framework.IOC.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class BaseService<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        //通过在子类的构造函数中注入，这里是基类，不用构造函数
        public IBaseRepository<TEntity> baseRepository;

        public async Task<bool> Delete(TEntity entity)
        {
            return await baseRepository.Delete(entity);
        }

        public async Task<bool> Delete(IList<TEntity> list)
        {
            return await baseRepository.Delete(list);
        }

        public async Task<bool> Insert(TEntity entity)
        {
            return await baseRepository.Insert(entity);
        }

        public async Task<bool> Insert(IList<TEntity> list)
        {
            return await baseRepository.Insert(list);
        }

        public IEnumerable<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereLambda)
        {
            return baseRepository.Query(whereLambda);
        }

        public IEnumerable<TEntity> Query(System.Linq.Expressions.Expression<Func<TEntity, bool>> whereLambda, System.Linq.Expressions.Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            return baseRepository.Query(whereLambda, orderLambda, isAsc, pageIndex, pageSize, ref totalCount);
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await baseRepository.Update(entity);
        }

        public async Task<bool> Update(IList<TEntity> list)
        {
            return await baseRepository.Update(list);
        }
    }
}
