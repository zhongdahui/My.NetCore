using My.NetCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Web.Entitys
{
    [AutoMapper(typeof(UserModel), typeof(UserDOT))]
    public class UserDOT
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string age { get; set; }
    }
}
