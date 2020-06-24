using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using My.NetCore.Framework.Options;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace My.NetCore.Framework.ORM.EntityFramework
{
    public class EntityFrameworkDbContext : DbContext
    {
        private readonly AppSettingOption _config;

        public EntityFrameworkDbContext(IOptions<AppSettingOption> config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (config.Value.DbContext == null)
                throw new ArgumentNullException(nameof(config.Value.DbContext));
            if (string.IsNullOrEmpty(config.Value.DbContext.ConnectionString))
                throw new ArgumentNullException(nameof(config.Value.DbContext.ConnectionString));
            if (string.IsNullOrEmpty(config.Value.DbContext.ModelAssemblyName))
                throw new ArgumentNullException(nameof(config.Value.DbContext.ModelAssemblyName));
            if (string.IsNullOrEmpty(config.Value.DbContext.DbType))
                throw new ArgumentNullException(nameof(config.Value.DbContext.DbType));
            _config = config.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_config.DbContext.DbType.ToUpper())
            {
                case "ORACLE":
                    throw new NotSupportedException("Oracle for EF Core Database Provider is not yet available.");
                case "MYSQL":
                    optionsBuilder.UseMySql(_config.DbContext.ConnectionString);
                    break;
                case "SQLSERVER":
                    optionsBuilder.UseSqlServer(_config.DbContext.ConnectionString);
                    break;
                case "SQLITE":
                    optionsBuilder.UseSqlite(_config.DbContext.ConnectionString);
                    break;
                case "MEMORY":
                    optionsBuilder.UseInMemoryDatabase(_config.DbContext.ConnectionString);
                    break;
                case "POSTGRESQL":
                    optionsBuilder.UseNpgsql(_config.DbContext.ConnectionString);
                    break;
                default:
                    optionsBuilder.UseMySql(_config.DbContext.ConnectionString);
                    break;
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assembly = Assembly.Load(_config.DbContext.ModelAssemblyName);

            foreach (Type type in assembly.ExportedTypes)
            {
                if (type.IsClass)
                {
                    var tableattrd = type.GetCustomAttribute(typeof(TableAttribute));

                    if (tableattrd != null)
                    {
                        var method = modelBuilder.GetType().GetMethods().Where(x => x.Name == "Entity").FirstOrDefault();

                        method = method.MakeGenericMethod(new Type[] { type });
                        method.Invoke(modelBuilder, null);
                    }
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
