using Microsoft.Extensions.Configuration;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddMSNetFrameworkConfiguration(
            this IConfigurationBuilder builder)
        {
            //var tempConfig = builder.Build();
            //var connectionString =
            //    tempConfig.GetConnectionString("WidgetConnectionString");

            return builder.Add(new MSNetFrameworkConfigurationSource());
        }
    }
}
