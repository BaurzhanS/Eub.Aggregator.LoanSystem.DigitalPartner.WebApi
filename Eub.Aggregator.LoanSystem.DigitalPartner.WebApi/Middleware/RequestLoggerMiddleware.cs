using Eub.Aggregator.LoanSystem.DigitalPartner.Application.Helpers;
using Microsoft.Extensions.Primitives;
using Serilog;
using System.Diagnostics;

namespace Eub.Aggregator.LoanSystem.DigitalPartner.WebApi.Middleware
{
    public class RequestLoggerMiddleware
    {
        private const string MessageTemplate =
          "{RequestMethod} responded {StatusCode} in {Elapsed:0.0000} ms";
        private readonly RequestDelegate next;

        public RequestLoggerMiddleware(RequestDelegate next, ILogger<RequestLoggerMiddleware> logger)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationIdStr = StringValues.Empty;
            Guid correlationId = Guid.Empty;

            var sw = Stopwatch.StartNew();

            if (context.Request.Headers.TryGetValue("X-Correlation-Id", out correlationIdStr))
            {
                try
                {
                    correlationId = ParceActivityId(correlationIdStr);
                }
                catch (Exception e)
                {
                    correlationId = Guid.NewGuid();
                }
            }
            else
            {
                correlationId = Guid.NewGuid();
            }

            CorrelationIdContext.SetCorrelationId(correlationId.ToString());

            using (Serilog.Context.LogContext.PushProperty("CorrelationID", correlationId))
            {
                await next.Invoke(context);

                sw.Stop();
                Log.Logger.Information(MessageTemplate,
                      context.GetRouteData().Values["controller"] + "/" + context.GetRouteData().Values["action"],
                      context.Response.StatusCode,
                      sw.Elapsed.TotalMilliseconds);
            }
        }

        /// <inheritdoc/>
        private Guid ParceActivityId(StringValues id)
        {
            Guid outId;
            if (Guid.TryParse(id, out outId))
            {
                return outId;
            }
            throw new InvalidCastException($"Cannot cast value {id}. Value have been Guid. Set valid ActivityId ");
        }
    }
}
