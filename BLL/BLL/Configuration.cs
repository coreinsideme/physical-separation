using Microsoft.Extensions.DependencyInjection;

using BLL.Interfaces;
using BLL.Services;

namespace BLL
{
    public static class Configuration
    {
        public static void ConfigureService(this ServiceCollection services)
        {
            services
                .AddSingleton<ICatalogService, CatalogService>()
                .AddSingleton<IProductService, ProductService>();
        }
    }
}