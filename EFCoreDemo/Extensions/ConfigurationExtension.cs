using EFCoreDemo.Configurations;

namespace EFCoreDemo.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection BindAppSettings(this IServiceCollection services, IConfiguration config)
        {
            AppSettings settings = new();
            config.Bind(settings);

            return services;
        }
    }
}
