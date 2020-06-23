using Microsoft.Extensions.Options;
using My.NetCore.Framework.IOC;
using My.NetCore.Framework.IOC.Attributes;
using My.NetCore.Framework.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace My.NetCore.Framework.CodeGenerator
{
    public class CodeGenerator
    {
        private static readonly string Delimiter = "\\";//分隔符，默认为windows下的\\分隔符
        private static readonly string ParentPath;//
        private static readonly AppSettingOption Option;

        static CodeGenerator()
        {
            Option = EnginContext.Current.Resolve<IOptions<AppSettingOption>>()?.Value;

            if (Option == null)
            {
                throw new ArgumentNullException(nameof(Option));
            }

            var path = AppDomain.CurrentDomain.BaseDirectory;
            var flag = path.IndexOf("/bin");
            if (flag > 0)
                Delimiter = "/";//如果可以取到值，修改分割符
            path = path.Substring(0, path.IndexOf(Delimiter + "bin"));
            ParentPath = path.Substring(0, path.LastIndexOf(Delimiter));
        }

        /// <summary>
        /// 生成指定的实体域名空间下各实体对应Repositories和Services层的基础代码文件
        /// </summary>
        /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
        public static void Generate(bool ifExsitedCovered = false)
        {
            var assembly = Assembly.Load(Option.CodeGenerate.ModelsNamespace);

            var types = assembly?.GetTypes();

            var list = types?.Where(t => t.IsClass && !t.IsGenericType && !t.IsAbstract && !t.IsNested);

            if (list != null)
            {
                foreach (var type in list)
                {
                    GenerateSingle(type, ifExsitedCovered);
                }
            }
        }

        /// <summary>
        /// 生成指定的实体对应IServices和Services层的基础代码文件
        /// </summary>
        /// <param name="modelType">实体类型（必须实现IBaseModel接口）</param>
        /// <param name="ifExsitedCovered">如果目标文件存在，是否覆盖。默认为false</param>
        private static void GenerateSingle(Type modelType, bool ifExsitedCovered = false)
        {
            var modelTypeName = modelType.Name;

            GenerateIRepository(modelTypeName, ifExsitedCovered);
            GenerateRepository(modelTypeName, ifExsitedCovered);
            GenerateIService(modelTypeName, ifExsitedCovered);
            GenerateService(modelTypeName, ifExsitedCovered);
        }

        private static void GenerateIRepository(string modelTypeName, bool ifExsitedCovered = false)
        {
            var iRepositoryPath = ParentPath + Delimiter + Option.CodeGenerate.IRepositoriesNamespace;

            if (!Directory.Exists(iRepositoryPath))
            {
                iRepositoryPath = ParentPath + Delimiter + "IRepositories";
                Directory.CreateDirectory(iRepositoryPath);
            }

            var fullPath = iRepositoryPath + Delimiter + "I" + modelTypeName + "Repository.cs";

            if (File.Exists(fullPath) && !ifExsitedCovered)
                return;

            var content = ReadTemplate("IRepositoryTemplate.txt");

            content = content.Replace("{ModelsNamespace}", Option.CodeGenerate.ModelsNamespace)
                .Replace("{IRepositoriesNamespace}", Option.CodeGenerate.IRepositoriesNamespace)
                .Replace("{ModelTypeName}", modelTypeName);
            WriteAndSave(fullPath, content);
        }

        private static void GenerateRepository(string modelTypeName, bool ifExsitedCovered = false)
        {
            var repositoryPath = ParentPath + Delimiter + Option.CodeGenerate.RepositoriesNamespace;

            if (!Directory.Exists(repositoryPath))
            {
                repositoryPath = ParentPath + Delimiter + "Repositories";
                Directory.CreateDirectory(repositoryPath);
            }

            var fullPath = repositoryPath + Delimiter +  modelTypeName + "Repository.cs";

            if (File.Exists(fullPath) && !ifExsitedCovered)
                return;

            var content = ReadTemplate("RepositoryTemplate.txt");

            content = content.Replace("{ModelsNamespace}", Option.CodeGenerate.ModelsNamespace)
                .Replace("{IRepositoriesNamespace}", Option.CodeGenerate.IRepositoriesNamespace)
                .Replace("{RepositoriesNamespace}", Option.CodeGenerate.RepositoriesNamespace)
                .Replace("{ModelTypeName}", modelTypeName);
            WriteAndSave(fullPath, content);
        }

        private static void GenerateIService(string modelTypeName, bool ifExsitedCovered = false)
        {
            var iServicePath = ParentPath + Delimiter + Option.CodeGenerate.IServiceNamespace;

            if (!Directory.Exists(iServicePath))
            {
                iServicePath = ParentPath + Delimiter + "IService";
                Directory.CreateDirectory(iServicePath);
            }

            var fullPath = iServicePath + Delimiter + "I" + modelTypeName + "Service.cs";

            if (File.Exists(fullPath) && !ifExsitedCovered)
                return;

            var content = ReadTemplate("IServiceTemplate.txt");

            content = content.Replace("{ModelsNamespace}", Option.CodeGenerate.ModelsNamespace)
                .Replace("{IServiceNamespace}", Option.CodeGenerate.IServiceNamespace)
                .Replace("{ModelTypeName}", modelTypeName);
            WriteAndSave(fullPath, content);
        }

        private static void GenerateService(string modelTypeName, bool ifExsitedCovered = false)
        {
            var servicePath = ParentPath + Delimiter + Option.CodeGenerate.ServiceNamespace;

            if (!Directory.Exists(servicePath))
            {
                servicePath = ParentPath + Delimiter + "Service";
                Directory.CreateDirectory(servicePath);
            }

            var fullPath = servicePath + Delimiter + modelTypeName + "Service.cs";

            if (File.Exists(fullPath) && !ifExsitedCovered)
                return;

            var content = ReadTemplate("ServiceTemplate.txt");

            content = content.Replace("{ModelsNamespace}", Option.CodeGenerate.ModelsNamespace)
                .Replace("{IServiceNamespace}", Option.CodeGenerate.IServiceNamespace)
                .Replace("{ServiceNamespace}", Option.CodeGenerate.ServiceNamespace)
                .Replace("{IRepositoriesNamespace}", Option.CodeGenerate.IRepositoriesNamespace)
                .Replace("{RepositoriesNamespace}", Option.CodeGenerate.RepositoriesNamespace)
                .Replace("{ModelTypeName}", modelTypeName);
            WriteAndSave(fullPath, content);
        }

        /// <summary>
        /// 从代码模板中读取内容
        /// </summary>
        /// <param name="templateName">模板名称，应包括文件扩展名称。比如：template.txt</param>
        /// <returns></returns>
        private static string ReadTemplate(string templateName)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            var content = string.Empty;

            using (var stream = currentAssembly.GetManifestResourceStream($"{currentAssembly.GetName().Name}.CodeGenerator.CodeTemplate.{templateName}"))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }
            return content;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        private static void WriteAndSave(string fileName, string content)
        {
            //实例化一个文件流--->与写入文件相关联
            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                //实例化一个StreamWriter-->与fs相关联
                using (var sw = new StreamWriter(fs))
                {
                    //开始写入
                    sw.Write(content);
                    //清空缓冲区
                    sw.Flush();
                    //关闭流
                    sw.Close();
                    fs.Close();
                }
            }
        }
    }
}
