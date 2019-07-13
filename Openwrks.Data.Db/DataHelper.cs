using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Openwrks.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Openwrks.Data.Db
{
    public static class DataHelper
    {
        public static void AddDataLayer(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<OpenwrksContext>(c =>
            {
                c.UseSqlServer(connStr);
            });

            var pocos = Assembly.Load("Openwrks.Data.Entities").DefinedTypes
                .Where(x => x.ImplementedInterfaces.Contains(typeof(IEntity)) && x.IsClass);

            Type iRepType = typeof(IRepository<>);
            Type repType = typeof(Repository<>);

            foreach (var type in pocos)
            {

                Type[] typeArgs = { type.AsType() };
                services.AddScoped(iRepType.MakeGenericType(typeArgs), repType.MakeGenericType(typeArgs));
            }
        }
    }
}
