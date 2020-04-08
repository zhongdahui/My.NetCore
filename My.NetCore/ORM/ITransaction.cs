using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.ORM
{
    public interface ITransaction 
    {
        void BeginTran();
        void CommitTran();
        void RollbackTran();
    }
}
