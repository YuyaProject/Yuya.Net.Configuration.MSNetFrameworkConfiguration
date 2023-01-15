using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Runtime;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    public class MSNetFrameworkConfigurationSource : IConfigurationSource
    {

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new MSNetFrameworkConfigurationProvider();
    }

    public class MSNetFrameworkConfigurationProvider : ConfigurationProvider
    {

        public override void Load()
        {
            Data = new Dictionary<string, string>()
            {
                {"Demo1", "demo1"}
            };
        }
    }


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
