using Microsoft.Extensions.DependencyInjection;
using SeninApi.Application.Exceptions;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using MediatR;
using SeninApi.Application.Beheviors;


namespace SeninApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevivor<,>));

        }
    }
}
