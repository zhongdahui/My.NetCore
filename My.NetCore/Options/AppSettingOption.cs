using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Options
{
    public class AppSettingOption
    {
        public DbContextOption DbContext { get; set; }     
        public AuthenticationOption Authentication{ get; set; }
        public JwtBearerOption JwtBearer { get; set; }
        public RedisOption Redis { get; set; }
        public ConsulOption Consul { get; set; }
        public SwaggerOption Swagger { get; set; }
        public SwitchOption Switch { get; set; }
        public RabbitMQOption RabbitMQ { get; set; }
        public FastDFSOption FastDFS { get; set; }
        public AutoMapperOption AutoMapper { get; set; }
        public CodeGenerateOption CodeGenerate { get; set; }
    }
}
