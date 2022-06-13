using Microsoft.Extensions.DependencyInjection;

using BLL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public static class Configuration
    {
        public static void ConfigureService(this ServiceCollection services)
        {
            services
                .AddSingleton<ICatalogRepository, CatalogRepository>()
                .AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}