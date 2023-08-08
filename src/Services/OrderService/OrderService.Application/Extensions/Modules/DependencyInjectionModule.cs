using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace OrderService.Application.Extensions.Modules
{
    public class DependencyInjectionModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterAssemblyTypes(apiAssembly).Where(
                x => x.Name.EndsWith("Validator")).AsImplementedInterfaces().InstancePerLifetimeScope();                
        }
    }
}
