using _0_Framework.Infrastructure;

using Application;
using Application.Contracts.Product;
using Application.Contracts.ProductCategory;
using Application.Contracts.ProductPicture;
using Domain.Product;
using Domain.ProductCategory;
using Domain.ProductPicture;
using Infrastructure.EFCore;
using Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

         

         
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}