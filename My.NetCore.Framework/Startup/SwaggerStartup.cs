using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.Options;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.IO;


namespace My.NetCore.Framework.Startup
{
    public static class SwaggerStartup
    {
        [Autowired]
        private static IOptions<AppSettingOption> Options { get; set; }

        public static void AddSwaggerStartup(this IServiceCollection services)
        {
            var option = Options;// EnginContext.Current.Resolve<IOptions<AppSettingOption>>();

            if (option == null) throw new ArgumentNullException(nameof(option));

            var swaggerSettingOption = option.Value.Swagger;

            if (services == null) throw new ArgumentNullException(nameof(services));
            if (swaggerSettingOption == null) throw new ArgumentNullException(nameof(swaggerSettingOption));

            //版本控制
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true; //可选配置，设置为true时，header返回版本信息
                options.ApiVersionReader = new QueryStringApiVersionReader("version");//HTTP Header报头传递
                options.AssumeDefaultVersionWhenUnspecified = true;//是否启用未指明版本API，指向默认版本
                options.DefaultApiVersion = new ApiVersion(1, 0);
            })
            .AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVVV";//api组名格式
                o.AssumeDefaultVersionWhenUnspecified = true;//是否提供API版本服务
            });

            //Swagger生成api文档
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Version = description.ApiVersion.ToString(),
                        Title = $"{swaggerSettingOption.Title}",
                        Description = swaggerSettingOption.Description
                    });
                }

                if (swaggerSettingOption.IsUseAnnotations)
                {
                    var basePath = AppContext.BaseDirectory;

                    string interfaceDescriptionsPath = swaggerSettingOption.InterfaceDescriptionsPath;
                    string modelDescriptionsPath = swaggerSettingOption.ModelDescriptionsPath;

                    if (!string.IsNullOrEmpty(interfaceDescriptionsPath) && !string.IsNullOrEmpty(modelDescriptionsPath))
                    {
                        try
                        {
                            var interface_list = interfaceDescriptionsPath.Split(',');

                            if(interface_list!=null&& interface_list.Length>0)
                            {
                                foreach (var item in interface_list)
                                {
                                    var xmlPath = Path.Combine(basePath, item);//这个就是刚刚配置的xml文件名
                                    options.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                                }
                            }

                            var model_list = modelDescriptionsPath.Split(',');

                            if (model_list != null && model_list.Length > 0)
                            {
                                foreach (var item in model_list)
                                {
                                    var xmlModelPath = Path.Combine(basePath, item);//这个就是Model层的xml文件名
                                    options.IncludeXmlComments(xmlModelPath);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }

                if (swaggerSettingOption.IsAuthorized)
                {
                    options.OperationFilter<AddResponseHeadersFilter>();
                    options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                    // 安全校验
                    options.OperationFilter<SecurityRequirementsOperationFilter>();

                    // 开启oauth2安全描述
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });
                }
            });
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseSwagger().UseSwaggerUI(options =>
            {
                var provider = builder.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}
