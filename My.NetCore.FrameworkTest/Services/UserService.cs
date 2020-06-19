using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.ORM.EntityFramework;
using My.NetCore.FrameworkTest.Entitys;
using My.NetCore.FrameworkTest.Repository;
using System;
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

        [Transaction]
        public void DoSomeThink()
        {
            _userRepository.Insert(new UserModel() { Age = 10, UserName = "myname1", BrithDate = DateTime.Now });
            int a1 = 10;
            int a2 = 0;
            int a3 = a1 / a2;
            _userRepository.Insert(new UserModel() { Age = 20, UserName = "myname2", BrithDate = DateTime.Now });
        }
    }
}
