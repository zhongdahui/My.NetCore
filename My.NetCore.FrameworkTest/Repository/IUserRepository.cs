using My.NetCore.Framework.ORM;
using My.NetCore.FrameworkTest.Entitys;

namespace My.NetCore.FrameworkTest.Repository
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUserByID(int id,string name);
    }
}
