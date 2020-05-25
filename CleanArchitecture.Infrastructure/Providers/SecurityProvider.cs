namespace CleanArchitecture.Infrastructure.Providers
{
    using Microsoft.Extensions.Configuration;

    public class SecurityProvider
    {
        private IConfiguration configuration;

        public SecurityProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.PasswordSalt = this.configuration.GetValue<string>("Security:5alt");
            this.Secret = this.configuration.GetValue<string>("Security:5ecret");
        }

        public string PasswordSalt { get; set; }

        public string Secret { get; set; }
    }
}
