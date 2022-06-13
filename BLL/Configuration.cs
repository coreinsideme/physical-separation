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
                .AddSingleton<ICategoryService, CategoryService>()
                .AddSingleton<IProductService, ProductService>();
        }
    }
}