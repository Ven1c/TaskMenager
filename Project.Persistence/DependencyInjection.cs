using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Project.Application.Interfaces;

namespace Project.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ProjectsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IProjectDbContext>(provider =>
                provider.GetService<ProjectsDbContext>());
            return services;
        }
    }
}