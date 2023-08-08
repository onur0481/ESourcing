using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace ProductService.Application.Extensions.Modules
{
    public class DependencyInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(apiAssembly).Where(
                x => x.Name.EndsWith("Validator")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
