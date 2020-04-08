using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Options
{
    public class ConsulOption
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string HealthCheck { get; set; }
        public string ConsulAddress { get; set; }
    }
}
