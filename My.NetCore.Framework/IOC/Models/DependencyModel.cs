﻿using System;

namespace My.NetCore.Framework.IOC.Models
{
    public class DependencyModel
    {

        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 生命周期
        /// </summary>
        public Lifetime Lifetime { get; set; }

        /// <summary>
        /// 实现接口
        /// </summary>
        public Type ImplementInterface { get; set; }
    }
}
