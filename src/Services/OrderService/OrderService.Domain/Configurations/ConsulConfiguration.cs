namespace OrderService.Domain.Configurations
{
    public class ConsulConfiguration
    {
        public string ConsulAddress { get; set; }

        public Uri ServiceAddress { get; set; }

        public string ServiceName { get; set; }

        public string ServiceId { get; set; }

        public ConsulConfiguration(string consulAddress, Uri serviceAddress, string serviceName, string serviceId)
        {
            ConsulAddress = consulAddress;
            ServiceAddress = serviceAddress;
            ServiceName = serviceName;
            ServiceId = serviceId;
        }
    }
}
