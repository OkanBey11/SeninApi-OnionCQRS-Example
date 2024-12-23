using Microsoft.Extensions.DependencyInjection;
using SeninApi.Application.Interfaces.AutoMapper;


namespace SeninApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
