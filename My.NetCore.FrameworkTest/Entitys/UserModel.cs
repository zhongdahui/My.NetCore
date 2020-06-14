using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.FrameworkTest.Entitys
{
    //[SugarTable("db_user")]
    [Table("User")]
    public class UserModel
    {

        public int ID { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public DateTime? BrithDate { get; set; }
    }
}
