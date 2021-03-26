using CompanyCreditCard.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyCreditCard.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
