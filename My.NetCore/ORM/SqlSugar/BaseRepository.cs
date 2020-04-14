using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.ORM.SqlSugar
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        public ISqlSugarClient DbClient { get; set; }

        public BaseRepository(IDbFactory dbFactory)
        {
            DbClient = dbFactory.GetDbContext();
        }

        public async Task<bool> DeleteById(object id)
        {
            return await DbClient.Deleteable<TEntity>(id).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await DbClient.Deleteable<TEntity>().In(ids).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(TEntity entity)
        {
            return await DbClient.Deleteable(entity).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Delete(IList<TEntity> list)
        {
            return await Task.Run(() => 1 == 2);
        }

        public async Task<bool> Insert(TEntity entity)
        {
            return await DbClient.Insertable(entity).ExecuteReturnIdentityAsync() > 0;
        }

        public async Task<bool> Insert(IList<TEntity> list)
        {
            return await DbClient.Insertable(list.ToArray()).ExecuteCommandAsync() > 0;
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda)
        {
            return DbClient.Queryable<TEntity>().WhereIF(whereLambda != null, whereLambda).ToList();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount)
        {
            var list = DbClient.Queryable<TEntity>().WhereIF(whereLambda != null, whereLambda);
            totalCount = list.Count();
            return list.OrderByIF(orderLambda != null, orderLambda, isAsc ? OrderByType.Asc : OrderByType.Desc).ToPageList(pageIndex, pageSize);
        }

        public async Task<bool> Update(TEntity entity)
        {
            return await DbClient.Updateable(entity).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(IList<TEntity> list)
        {
            return await Task.Run(() => 1 == 2);
        }

        public IEnumerable<TEntity> Query(string sql)
        {
            return DbClient.Ado.SqlQuery<TEntity>(sql);
        }
        public int Execute(string sql)
        {
            return DbClient.Ado.ExecuteCommand(sql);
        }
    }
}
