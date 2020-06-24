using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.ORM;
using My.NetCore.FrameworkTest.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Services
{
    public interface IUserService : IBaseServices<UserModel>
    {
        UserModel GetUserByID(int id, string name);

        IEnumerable<UserModel> GetUserByID();

        UserModel InsertUser(int id, string name, UserModel model);

        void DoSomeThink();
    }
}
