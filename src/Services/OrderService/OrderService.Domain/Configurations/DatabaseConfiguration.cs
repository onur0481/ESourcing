namespace OrderService.Domain.Configurations
{
    public class DatabaseConfiguration
    {
        public string OrderDBConnectionString { get; private set; }

        public DatabaseConfiguration(string orderDBConnectionString)
        {
            OrderDBConnectionString = orderDBConnectionString;
        }
    }
}
