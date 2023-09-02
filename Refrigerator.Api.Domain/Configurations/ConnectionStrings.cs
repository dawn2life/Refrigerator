namespace Refrigerator.Api.Domain.Configurations
{
    public class ConnectionStrings
    {
        public ConnectionInfo RefrigeratorDb { get; set; }

    }
    public class ConnectionInfo
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }

}
