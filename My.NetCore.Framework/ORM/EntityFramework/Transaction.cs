using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class Transaction : ITransaction
    {
        private readonly EntityFrameworkDbContext _entityFrameworkDbContext;

        public Transaction(EntityFrameworkDbContext entityFrameworkDbContext)
        {
            _entityFrameworkDbContext = entityFrameworkDbContext;
        }

        public void BeginTran()
        {
            _entityFrameworkDbContext.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _entityFrameworkDbContext.Database.CommitTransaction();
        }

        public void RollbackTran()
        {
            _entityFrameworkDbContext.Database.RollbackTransaction();
        }
    }
}
