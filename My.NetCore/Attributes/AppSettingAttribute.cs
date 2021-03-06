﻿using System;

namespace My.NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class AppSettingAttribute : Attribute
    {
        /// <summary>
        /// 如果没有值，映射根节点
        /// </summary>
        public string SectionKey { get; set; }

        public AppSettingAttribute(string sectionKey)
        {
            SectionKey = sectionKey;
        }

        public AppSettingAttribute()
        {
        }
    }
}
