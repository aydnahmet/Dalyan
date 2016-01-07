using System.Reflection;
using Dalyan.Service;
using SimpleInjector;
using SimpleInjector.Extensions;
using System.Data.Linq;
using System.Data.Entity;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using System.IO;
using System;
//using Dalyan.Domain.Interfaces;
//using Dalyan.Db;
//using Dalyan.Domain;
using Owin;
using SimpleInjector.Extensions.ExecutionContextScoping;
using Microsoft.Owin.Security.OAuth;

namespace Dalyan.WebApi
{
    public static class Bootstrapper
    {
        public static Container Container;
        public static IAppBuilder app;

        public static void Bootstrap()
        {
            //Container = new Container();

            //// Register your types, for instance using the RegisterWebApiRequest
            //// extension from the integration package:
            //Container.RegisterWebApiRequest<Mediator>();

            //// This is an extension method from the integration package.
            //Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            //// Here your usual Web API configuration stuff.

            ////Container.RegisterAllOpenGeneric(typeof(IQueryHandler<,>), typeof(AuthLoginQueryHandler));
            //Container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), typeof(IQueryHandler<,>).Assembly);

            //Container.RegisterSingle(typeof(DbContext), new DbEntities());
            //Container.RegisterSingle(typeof(IMediator), typeof(Mediator));
            ////Container.RegisterSingle(typeof(ILog), typeof(Dalyan.Logger.Log));
            ////Container.RegisterSingle(typeof(IPanelContext), new PanelContext());

            //Container.Verify();

            //GlobalConfiguration.Configuration.DependencyResolver =
            //    new SimpleInjectorWebApiDependencyResolver(Container);

        }

        //Container.RegisterSingleton<IMediator, Mediator>();
        //Container.Register(typeof(IQueryHandler<,>), assemblies);
        //Container.RegisterCollection(typeof(IQueryHandler<,>), assemblies);
        //Container.RegisterSingleton(typeof(DbContext), new DbEntities());

    }
}