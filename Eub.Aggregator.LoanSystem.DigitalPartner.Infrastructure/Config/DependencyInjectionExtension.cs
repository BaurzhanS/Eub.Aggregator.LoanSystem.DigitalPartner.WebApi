using Eub.Adapter.Way4.Transactional.DigitalPartner;
using Eub.Adapter.Way4Ufx.Info.gRPC.Protos.V1;
using Eub.Aggregator.LoanSystem.DigitalPartner.Application.IRepositoryServices;
using Eub.Aggregator.LoanSystem.DigitalPartner.Infrastructure.Interceptors;
using Eub.Aggregator.LoanSystem.DigitalPartner.Infrastructure.Repository;
using Grpc.Core;
using Grpc.Net.Client.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.Infrastructure.Config
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructureLayer(
           this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDigitalPartnerRepo, DigitalPartnerRepo>();
            AddGrpcClientFactory(services, configuration);
            return services;
        }

        private static void AddGrpcClientFactory(IServiceCollection services, IConfiguration configuration)
        {
            var circuitBreakerPolicy = Policy
                                    .Handle<RpcException>()
                                    .CircuitBreakerAsync(
                                     exceptionsAllowedBeforeBreaking: 5,
                                     durationOfBreak: TimeSpan.FromSeconds(30)).AsAsyncPolicy<HttpResponseMessage>();

            var methodConfig = new MethodConfig
            {
                Names = { MethodName.Default },
                RetryPolicy = new RetryPolicy
                {
                    MaxAttempts = 3,
                    InitialBackoff = TimeSpan.FromSeconds(3),
                    MaxBackoff = TimeSpan.FromSeconds(3),
                    BackoffMultiplier = 1,
                    RetryableStatusCodes =
                    {
                       StatusCode.Unauthenticated, StatusCode.NotFound, StatusCode.Unavailable, StatusCode.Internal
                    }
                }
            };
            services.AddGrpcClient<UfxInfo.UfxInfoClient>(o =>
            {
                o.Address = new Uri(configuration.GetValue<string>("Adapters:Way4UFX"));
                o.ChannelOptionsActions.Add(options =>
                {
                    options.ServiceConfig = new ServiceConfig { MethodConfigs = { methodConfig } };
                });
            }).AddPolicyHandler(circuitBreakerPolicy).AddInterceptor(() => new RequestHeaderInterceptor());

            services.AddGrpcClient<Way4TransactionalDigitalPartner.Way4TransactionalDigitalPartnerClient>(o =>
            {
                o.Address = new Uri(configuration.GetValue<string>("Adapters:Way4"));
                o.ChannelOptionsActions.Add(options =>
                {
                    options.ServiceConfig = new ServiceConfig { MethodConfigs = { methodConfig } };
                });
            }).AddPolicyHandler(circuitBreakerPolicy).AddInterceptor(() => new RequestHeaderInterceptor());
        }
    }
}
