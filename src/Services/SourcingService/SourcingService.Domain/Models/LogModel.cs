namespace SourcingService.Domain.Models
{
    public class LogModel
    {
        public string ServiceName { get; private set; }

        public string RequestMethod { get; private set; }

        public string RequestPath { get; private set; }

        public string RequestID { get; private set; }

        public string IpAddress { get; private set; }

        public int ResponseStatusCode { get; private set; }

        public long ElapsedTimeInMilliseconds { get; private set; }

        public string? ErrorMessage { get; private set; }

        public string? InnerExceptionMessage { get; private set; }

        public LogModel(string serviceName, string requestMethod, string requestPath, string requestID, string ipAddress, int responseStatusCode, long elapsedTimeInMilliseconds, string? errorMessage, string? innerExceptionMessage)
        {
            ServiceName = serviceName;
            RequestMethod = requestMethod;
            RequestPath = requestPath;
            RequestID = requestID;
            IpAddress = ipAddress;
            ResponseStatusCode = responseStatusCode;
            ElapsedTimeInMilliseconds = elapsedTimeInMilliseconds;
            ErrorMessage = errorMessage;
            InnerExceptionMessage = innerExceptionMessage;
        }
    }
}
