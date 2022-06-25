using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System.Reflection;
using TicketSystem.Core.Abstract.Entities;
using TicketSystem.Core.Utilities.Interceptors;
using AppContext = TicketSystem.DataAccess.Concrete.EntityFramework.AppContext;
using Module = Autofac.Module;

namespace TicketSystem.Business.DependencyResolver.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Assembly Appending
            var businessAssembly = Assembly.GetAssembly(typeof(BusinessModule));
            var coreAssembly = Assembly.GetAssembly(typeof(IEntity));
            var dataAccessAssembly = Assembly.GetAssembly(typeof(AppContext));

            builder.RegisterAssemblyTypes(dataAccessAssembly!).Where(x => x.Name.StartsWith("Ef") && x.Name.EndsWith("Dal")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(businessAssembly!).Where(x => x.Name.EndsWith("Manager")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(businessAssembly!).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            #endregion
        }
    }
}
