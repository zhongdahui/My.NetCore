﻿using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.ORM.SqlSugar;
using My.NetCore.FrameworkTest.Entitys;
using System;

namespace My.NetCore.FrameworkTest.Repository
{
    [Repository]
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        //public UserRepository(EntityFrameworkDbContext entityFrameworkDbContext) : base(entityFrameworkDbContext)
        //{

        //}

        public UserModel GetUserByID(int id, string name)
        {
            return new UserModel() { ID = 1, UserName = "admin", Age = 12, BrithDate = DateTime.Now };
        }
    }
}
