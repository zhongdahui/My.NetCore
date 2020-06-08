using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Options
{
    public class SwaggerOption
    {
        public string Title { get; set; } = "API文档";
        public string Description { get; set; } = "API文档";
        public string Version { get; set; } = "v1";

        public string RoutePrefix { get; set; } = "";

        public string InterfaceDescriptionsPath { get; set; }
        public string ModelDescriptionsPath { get; set; }
        /// <summary>
        /// 是否开启权限
        /// </summary>
        public bool IsAuthorized { get; set; } = false;
        /// <summary>
        /// 是否使用说明
        /// </summary>
        public bool IsUseAnnotations { get; set; } = false;
    }
}
