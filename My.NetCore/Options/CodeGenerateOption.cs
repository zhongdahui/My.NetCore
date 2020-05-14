using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Options
{
    public class CodeGenerateOption
    {
        public string ModelsNamespace { get; set; }
        public string ControllersNamespace { get; set; }
        public string IServiceNamespace { get; set; }
        public string ServiceNamespace { get; set; }
        public string IRepositoriesNamespace { get; set; }
        public string RepositoriesNamespace { get; set; }
    }
}
