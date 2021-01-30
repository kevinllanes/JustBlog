[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(JustBlog.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(JustBlog.UI.App_Start.NinjectWebCommon), "Stop")]

namespace JustBlog.UI.App_Start
{
    using AutoMapper;
    using JustBlog.Core.Common.UnitOfWork;
    using JustBlog.Data.Common.UnitOfWork;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // unit of work per request
            //kernel.Bind<IPageRepository>().To<PageRepository>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            // kernel.Bind<IPageRepository>().To<PageRepository>().InSingletonScope();

            //kernel.Bind<IPageService>().To<PageService>().InSingletonScope();

            //default binding for everything except unit of work
            //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());

            kernel.Bind<IMapper>()
                 .ToMethod(context =>
                 {
                     var config = new MapperConfiguration(cfg =>
                     {
                         cfg.AddProfile<MapperProfile>();
                         // tell automapper to use ninject when creating value converters and resolvers
                         cfg.ConstructServicesUsing(t => kernel.Get(t));
                     });
                     return config.CreateMapper();
                 }).InSingletonScope();
        }        
    }
}
