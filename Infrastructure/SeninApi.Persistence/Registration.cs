using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeninApi.Application.Interfaces.Repositories;
using SeninApi.Application.Interfaces.UnitOfWorks;
using SeninApi.Persistence.Context;
using SeninApi.Persistence.Repositories;
using SeninApi.Persistence.UnitOfWorks;

namespace SeninApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
