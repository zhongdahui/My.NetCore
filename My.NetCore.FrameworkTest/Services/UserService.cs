using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.FrameworkTest.Entitys;
using My.NetCore.FrameworkTest.Repository;
using System.Collections.Generic;

namespace My.NetCore.FrameworkTest.Services
{
    [Service]
    public class UserService :  BaseService<UserModel>, IUserService
    {
        [Autowired]
        private IUserRepository _userRepository { get; set; }

        public IEnumerable<UserModel> GetUserByID()
        {
            return _userRepository.Query(w => w.ID > 1);
        }

        public UserModel GetUserByID(int id, string name)
        {
            return _userRepository.GetUserByID(id, name);
        }

        public UserModel InsertUser(int id, string name, UserModel model)
        {
            return null;
        }
    }
}
