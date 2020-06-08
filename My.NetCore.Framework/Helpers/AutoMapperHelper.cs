using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.Attributes;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace My.NetCore.Framework.Helpers
{
    public static class AutoMapperHelper
    {
        private static IMapper mapper;

        [Autowired]
        private static IOptions<AppSettingOption> Options { get; set; }

        static AutoMapperHelper()
        {
            var config = Options;// EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (config.Value.AutoMapper == null)
                throw new ArgumentNullException(nameof(config.Value.AutoMapper));

            var assemblyName = config.Value.AutoMapper.AssemblyName;
            MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();

            if (assemblyName != null && assemblyName.Count > 0)
            {
                foreach (var item in assemblyName)
                {
                    var attributes = Assembly.Load(item).GetTypes()
                        .Where(_type => _type.GetCustomAttribute<AutoMapperAttribute>() != null)
                        .Select(_type => _type.GetCustomAttribute<AutoMapperAttribute>());

                    if (attributes != null && attributes.Any())
                    {
                        foreach (var attribute in attributes)
                        {
                            mapperConfigurationExpression.CreateMap(attribute.SourceType, attribute.TargetType);
                        }
                    }
                }
            }

            var instance = new MapperConfiguration(mapperConfigurationExpression);
            instance.AssertConfigurationIsValid();
            mapper = instance.CreateMapper();
        }

        public static TDestination Map<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TDestination>(this object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            return mapper.Map<List<TDestination>>(source);
        }

        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return mapper.Map<List<TDestination>>(source);
        }
    }
}
