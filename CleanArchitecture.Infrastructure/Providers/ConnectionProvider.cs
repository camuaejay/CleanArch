namespace CleanArchitecture.Infrastructure.Providers
{
    using Microsoft.Extensions.Configuration;

    public class ConnectionProvider
    {
        private IConfiguration configProvider;

        public ConnectionProvider(IConfiguration configProvider)
        {
            this.configProvider = configProvider;
            this.DBConnection = this.configProvider.GetValue<string>("Connection:DBConnection");
        }

        public string DBConnection { get; set; }
    }
}
