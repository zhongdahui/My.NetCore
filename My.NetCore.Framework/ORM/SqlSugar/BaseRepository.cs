using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.SqlSugar
{
    public class BaseRepository<TEntity> : Transaction, IBaseRepository<TEntity> where TEntity : class, new()
    {
        public bool Insert(TEntity entity)
        {
            return DbClient.Insertable(entity).ExecuteCommandIdentityIntoEntity();
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            return await DbClient.Insertable(entity).ExecuteCommandIdentityIntoEntityAsync();
        }

        public bool Insert(IList<TEntity> list)
        {
            List<TEntity> lisss = new List<TEntity>();

            return DbClient.Insertable(list.ToArray()).ExecuteCommand() > 0;
        }

        public async Task<bool> InsertAsync(IList<TEntity> list)
        {
            return await DbClient.Insertable(list.ToArray()).ExecuteCommandAsync() > 0;
        }

        public bool Update(TEntity entity)
        {
            return DbClient.Updateable(entity).ExecuteCommandHasChange();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            return await DbClient.Updateable(entity).ExecuteCommandHasChangeAsync();
        }

        public bool Update(IList<TEntity> list)
        {
            return DbClient.Updateable(list.ToList()).ExecuteCommandHasChange();
        }

        public async Task<bool> UpdateAsync(IList<TEntity> list)
        {
            return await DbClient.Updateable(list.ToList()).ExecuteCommandHasChangeAsync();
        }

        public bool DeleteByID(object id)
        {
            return DbClient.Deleteable<TEntity>(id).ExecuteCommandHasChange();
        }

        public async Task<bool> DeleteByIDAsync(object id)
        {
            return await DbClient.Deleteable<TEntity>(id).ExecuteCommandHasChangeAsync();
        }

        public bool DeleteByIds(object[] ids)
        {
            return DbClient.Deleteable<TEntity>().In(ids).ExecuteCommandHasChange();
        }

        public async Task<bool> DeleteByIdsAsync(object[] ids)
        {
            return await DbClient.Deleteable<TEntity>().In(ids).ExecuteCommandHasChangeAsync();
        }

        public bool Delete(TEntity entity)
        {
            return DbClient.Deleteable(entity).ExecuteCommandHasChange();
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            return await DbClient.Deleteable(entity).ExecuteCommandHasChangeAsync();
        }

        public bool Delete(IList<TEntity> list)
        {
            return DbClient.Deleteable(list.ToList()).ExecuteCommandHasChange();
        }

        public async Task<bool> DeleteAsync(IList<TEntity> list)
        {
            return await DbClient.Deleteable(list.ToList()).ExecuteCommandHasChangeAsync();
        }

        public TEntity GetModel(object id)
        {
            return DbClient.Queryable<TEntity>().InSingle(id);
        }

        public async Task<TEntity> GetModelAsync(object id)
        {
            return await DbClient.Queryable<TEntity>().InSingleAsync(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda)
        {
            return DbClient.Queryable<TEntity>().WhereIF(whereLambda != null, whereLambda).ToList();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            var list = DbClient.Queryable<TEntity>().WhereIF(whereLambda != null, whereLambda);
            totalCount = list.Count();
            return list.OrderByIF(orderLambda != null, orderLambda, isAsc ? OrderByType.Asc : OrderByType.Desc).ToPageList(pageIndex, pageSize);
        }

        public IEnumerable<T> SqlQuery<T>(string sql)
        {
            return DbClient.Ado.SqlQuery<T>(sql);
        }

        public int ExecuteCommand(string sql)
        {
            return DbClient.Ado.ExecuteCommand(sql);
        }

        public int ExecuteScale(string sql)
        {
            return DbClient.Ado.GetInt(sql);
        }
    }
}
