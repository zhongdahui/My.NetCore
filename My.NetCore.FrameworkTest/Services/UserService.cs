using My.NetCore.Framework.Attributes;
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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            base.baseRepository = _userRepository;
        }

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
            //_userRepository.Insert(new UserModel() { Age = 10, UserName = "myname1", BrithDate = DateTime.Now });
            //int a = 1;
            //int b = 0;
            //int c = a / b;
            _userRepository.Insert(new UserModel() { Age = 20, UserName = "myname2", BrithDate = DateTime.Now });
        }
    }
}
