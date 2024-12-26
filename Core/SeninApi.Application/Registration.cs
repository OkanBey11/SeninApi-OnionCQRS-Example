using Microsoft.Extensions.DependencyInjection;
using SeninApi.Application.Exceptions;
using System.Reflection;
using FluentValidation;
using System.Globalization;
using MediatR;
using SeninApi.Application.Beheviors;
using SeninApi.Application.Features.Products.Rules;
using SeninApi.Application.Bases;


namespace SeninApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevivor<,>));

        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var t in types)
                services.AddSingleton(t);

            return services;
        }
    }
}
