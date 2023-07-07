using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PCWebShop.Core.Interfaces;
using PCWebShop.Core.Services;


namespace PCWebShop.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services DI.
            services.AddLogging();
            services.AddHttpContextAccessor();

            services.AddScoped<INarudzbaService, NarudzbaService>();
           
        }
    }
}
