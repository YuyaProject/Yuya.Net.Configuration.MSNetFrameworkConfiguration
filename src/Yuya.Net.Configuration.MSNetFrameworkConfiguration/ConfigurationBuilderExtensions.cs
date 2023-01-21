using Microsoft.Extensions.Configuration;
using System;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddMSNetFrameworkConfiguration(
        this IConfigurationBuilder builder, Action<MSNetFrameworkConfigurationSource> configurationAction = null)
    {
        var src = new MSNetFrameworkConfigurationSource();

        configurationAction?.Invoke(src);

        return builder.Add(src);
    }
}
