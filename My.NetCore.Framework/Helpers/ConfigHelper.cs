using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using My.NetCore.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Framework.Helpers
{
    public class ConfigHelper
    {
        public static IConfiguration Configuration { get; set; }

        public ConfigHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string GetSetting(params string[] sections)
        {
            if (sections.Any())
            {
                return Configuration[string.Join(":", sections)];
            }
            return "";
        }

        public static string GetSetting(string section)
        {
            if (section.Any())
            {
                return Configuration[section];
            }
            return "";
        }

        public static T GetSetting<T>(string section) where T : class, new()
        {
            if (section.Any())
            {
                return Configuration.GetSection(section).Get<T>();
            }
            return null;
        }
    }
}
