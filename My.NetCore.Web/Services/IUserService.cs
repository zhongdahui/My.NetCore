using My.NetCore.ORM;
using My.NetCore.Web.Entitys;
using System.Collections.Generic;

namespace My.NetCore.Web.Services
{
    public interface IUserService : IBaseServices<UserModel>
    {
        UserModel GetUserByID(int id,string name);

        IEnumerable<UserModel> GetUserByID();

        UserModel InsertUser(int id, string name, UserModel model);
    }
}
