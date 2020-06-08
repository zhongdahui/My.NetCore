using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class Transaction<TDbContext> : ITransaction where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public Transaction(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTran()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            try
            {
                _dbContext.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                _dbContext.Database.RollbackTransaction();
                throw ex;
            }
        }

        public void RollbackTran()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
