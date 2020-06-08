﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        Task<bool> Insert(TEntity entity);
        Task<bool> Insert(IList<TEntity> list);
        Task<bool> Update(TEntity entity);
        Task<bool> Update(IList<TEntity> list);
        Task<bool> Delete(TEntity entity);
        Task<bool> Delete(IList<TEntity> list);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, object>> orderLambda, bool isAsc, int pageIndex, int pageSize, ref int totalCount);
    }
}
