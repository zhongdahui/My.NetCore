using My.NetCore.Framework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace My.NetCore.Framework.AutoMapper
{
    public class AutoMapperFactory
    {
        public List<(Type, Type)> ConvertList { get; } = new List<(Type, Type)>();

        public void AddAssemblys(params Assembly[] assemblys)
        {
            foreach (var assembly in assemblys)
            {
                var attributes = assembly.GetTypes().Where(_type => _type.GetCustomAttribute<AutoMapperAttribute>() != null)
                    .Select(_type => _type.GetCustomAttribute<AutoMapperAttribute>());

                if (attributes != null && attributes.Any())
                {
                    foreach (var attribute in attributes)
                    {
                        ConvertList.Add((attribute.SourceType, attribute.TargetType));
                    }
                }
            }
        }
    }
}
