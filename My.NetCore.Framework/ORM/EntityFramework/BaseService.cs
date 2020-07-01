using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class BaseService<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        //通过在子类的构造函数中注入，这里是基类，不用构造函数
        public IBaseRepository<TEntity> baseRepository;

        public bool Insert(TEntity entity)
        {
            return baseRepository.Insert(entity);
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            return await baseRepository.InsertAsync(entity);
        }

        public bool Insert(IList<TEntity> list)
        {
            return baseRepository.Insert(list);
        }

        public async Task<bool> InsertAsync(IList<TEntity> list)
        {
            return await baseRepository.InsertAsync(list);
        }

        public bool Update(TEntity entity)
        {
            return baseRepository.Update(entity);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await baseRepository.UpdateAsync(entity);
        }

        public bool Update(IList<TEntity> list)
        {
            return baseRepository.Update(list);
        }

        public async Task<bool> UpdateAsync(IList<TEntity> list)
        {
            return await baseRepository.UpdateAsync(list);
        }

        public bool DeleteByID(object id)
        {
            return baseRepository.DeleteByID(id);
        }

        public async Task<bool> DeleteByIDAsync(object id)
        {
            return await baseRepository.DeleteByIDAsync(id);
        }

        public bool DeleteByIds(object[] ids)
        {
            return baseRepository.DeleteByIds(ids);
        }

        public async Task<bool> DeleteByIdsAsync(object[] ids)
        {
            return await baseRepository.DeleteByIdsAsync(ids);
        }

        public bool Delete(TEntity entity)
        {
            return baseRepository.Delete(entity);
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await baseRepository.DeleteAsync(entity);
        }

        public bool Delete(IList<TEntity> list)
        {
            return baseRepository.Delete(list);
        }

        public async Task<bool> DeleteAsync(IList<TEntity> list)
        {
            return await baseRepository.DeleteAsync(list);
        }

        public TEntity GetModel(object id)
        {
            return baseRepository.GetModel(id);
        }

        public async Task<TEntity> GetModelAsync(object id)
        {
            return await baseRepository.GetModelAsync(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda)
        {
            return baseRepository.GetList(whereLambda);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            return baseRepository.GetList(whereLambda, orderLambda, isAsc, pageIndex, pageSize, ref totalCount);
        }
    }
}
