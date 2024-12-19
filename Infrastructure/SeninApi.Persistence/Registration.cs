using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeninApi.Application.Interfaces.Repositories;
using SeninApi.Persistence.Context;

namespace SeninApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(IReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(IWriteRepository<>));
        }
    }
}
