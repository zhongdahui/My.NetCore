using My.NetCore.Attributes;
using My.NetCore.ORM.EntityFramework;
using My.NetCore.Web.Entitys;
using My.NetCore.Web.Repository;
using System.Collections.Generic;

namespace My.NetCore.Web.Services
{
    [Service]
    public class UserService : BaseService<UserModel>, IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            base.baseRepository = userRepository;
        }

        public IEnumerable<UserModel> GetUserByID()
        {
            return _userRepository.Query(w => w.ID > 0);
        }

        public UserModel GetUserByID(int id, string name)
        {
            return null;
        }

        public UserModel InsertUser(int id, string name, UserModel model)
        {
            return null;
        }
    }
}
