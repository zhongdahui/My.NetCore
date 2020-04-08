using My.NetCore.ORM;
using My.NetCore.Web.Entitys;

namespace My.NetCore.Web.Repository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUserByID(int id,string name);
    }
}
