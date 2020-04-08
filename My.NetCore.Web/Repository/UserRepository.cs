using System;
using My.NetCore.Attributes;
using My.NetCore.ORM.EntityFramework;
using My.NetCore.Web.Entitys;

namespace My.NetCore.Web.Repository
{
    [Repository]
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(EntityFrameworkDbContext sqlSugarDbContext) : base(sqlSugarDbContext) { }

        public UserModel GetUserByID(int id,string name)
        {
            return new UserModel() { ID = 1, UserName = "admin", Age = 12, BrithDate = DateTime.Now };
        }
    }
}
