using Serilog.Context;
using Serilog.Core;
using Serilog.Core.Enrichers;
using Web.APIGateway.Models;

namespace Web.APIGateway.Helpers
{
    public class LoggerHelper
    {
        private static readonly string ServiceName = "ServiceName";
        private static readonly string RequestMethodProperty = "RequestMethod";
        private static readonly string RequestPathProperty = "RequestPath";
        private static readonly string RequestIDProperty = "RequestID";
        private static readonly string IpAddressProperty = "IpAddress";
        private static readonly string ResponseStatusCodeProperty = "ResponseStatusCode";
        private static readonly string ElapsedTimeProperty = "ElapsedTime";
        private static readonly string ErrorMessageProperty = "ErrorMessage";
        private static readonly string InnerExceptionMessageProperty = "InnerExceptionMessage";

        public static void Log(LogModel logModel)
        {
            LogEnricher(logModel);

            if (logModel.ErrorMessage != null)
            {
                Serilog.Log.Logger.Error($"{logModel.RequestMethod} {logModel.RequestPath}");
            }
            else
            {
                Serilog.Log.Logger.Information($"{logModel.RequestMethod} {logModel.RequestPath}");
            }
        }

        private static void LogEnricher(LogModel logModel)
        {
            List<ILogEventEnricher> enrichers = new()
            {
                new PropertyEnricher(ServiceName, logModel.ServiceName),
                new PropertyEnricher(RequestMethodProperty, logModel.RequestMethod),
                new PropertyEnricher(RequestPathProperty, logModel.RequestPath),
                new PropertyEnricher(RequestIDProperty, logModel.RequestID),
                new PropertyEnricher(IpAddressProperty, logModel.IpAddress),
                new PropertyEnricher(ResponseStatusCodeProperty, logModel.ResponseStatusCode),
                new PropertyEnricher(ElapsedTimeProperty, logModel.ElapsedTimeInMilliseconds)
            };

            if (logModel.ErrorMessage != null)
            {
                enrichers.Add(new PropertyEnricher(ErrorMessageProperty, logModel.ErrorMessage));

                if (logModel.InnerExceptionMessage != null)
                {
                    enrichers.Add(new PropertyEnricher(InnerExceptionMessageProperty, logModel.InnerExceptionMessage));
                }
            }

            LogContext.Push(enrichers.ToArray());
        }

    }
}
