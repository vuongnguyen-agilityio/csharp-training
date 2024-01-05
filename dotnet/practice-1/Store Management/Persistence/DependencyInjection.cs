using Application.Data;
using Domain.Carts;
using Domain.Products;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using Domain.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseNpgsql(configuration.GetConnectionString("Database")));

            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<ICartRepository, CartRepository>();

            services.AddScoped<IPurchaseHistoryRepository, PurchaseHistoryRepository>();

            services.AddScoped<IPurchaseHistoryItemRepository, PurchaseHistoryItemRepository>();

            return services;
        }
    }
}
