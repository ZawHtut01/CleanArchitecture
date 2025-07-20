

using CleanArchitecture.Application;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infra.Data;
using CleanArchitecture.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("ConnectionString 'Default Connection' Not Found......")
                    );
            });

            services.AddTransient<IBlogReporitory, BlogRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<BlogDbContext>());

            return services;
        }
    }
}
