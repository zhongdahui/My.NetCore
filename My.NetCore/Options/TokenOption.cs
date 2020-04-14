using System;

namespace My.NetCore.Options
{
    public class TokenOption
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// 用户职能
        /// </summary>
        public string UserWork { get; set; }

        /// <summary>
        /// 用户数据
        /// </summary>
        public string UserData { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}
