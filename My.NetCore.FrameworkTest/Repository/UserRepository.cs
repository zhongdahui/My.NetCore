using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.FrameworkTest.Entitys;
using System;

namespace My.NetCore.FrameworkTest.Repository
{
    [Repository]
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserModel GetUserByID(int id, string name)
        {
            return new UserModel() { ID = 1, UserName = "admin", Age = 12, BrithDate = DateTime.Now };
        }
    }
}
