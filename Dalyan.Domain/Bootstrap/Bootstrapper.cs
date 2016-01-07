using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Extensions;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using Dalyan.Db;
using Dalyan.Entities.Interfaces;
using Dalyan.Domain.Logger;

namespace Dalyan.Domain.Bootstrap
{
    public static class Bootstrapper
    {
        public static void Setup(Container container)
        {
            IocSetup(container);
        }

        private static void IocSetup(Container container)
        {
            var assemblies = GetAssemblies().ToArray();
            
            container.RegisterSingleton<IMediator, Mediator>();
            container.RegisterSingleton<ILog, Log>();
            container.Register(typeof(IQueryHandler<,>), assemblies);
            container.RegisterCollection(typeof(IQueryHandler<,>), assemblies);
            container.RegisterSingleton(typeof(DbContext), new DbEntities());
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).Assembly;
        }
    }
}
