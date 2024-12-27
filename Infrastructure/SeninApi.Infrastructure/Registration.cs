using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeninApi.Infrastructure.Tokens;


namespace SeninApi.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
        }
    }
}
