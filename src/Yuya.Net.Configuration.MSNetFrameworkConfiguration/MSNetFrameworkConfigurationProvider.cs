using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class MSNetFrameworkConfigurationProvider : ConfigurationProvider
{
    private readonly List<IConfigurationReaderProvider> _providers;

    public MSNetFrameworkConfigurationProvider(List<IConfigurationReaderProvider> providers)
    {
        _providers = providers ?? new();
    }

    public override void Load()
    {
        Data = new Dictionary<string, string>();

        foreach (var provider in _providers)
        {
            foreach (var item in provider.GetAll())
            {
                Data[item.Key] = item.Value;
            }
        }
    }
}