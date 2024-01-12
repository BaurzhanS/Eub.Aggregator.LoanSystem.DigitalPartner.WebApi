using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Application.Config
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationLayer(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<DigitalPartnerService>();

            return services;
        }
    }
}
