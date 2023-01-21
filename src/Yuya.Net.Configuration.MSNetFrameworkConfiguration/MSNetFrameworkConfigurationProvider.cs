using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

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
        if (_providers == null || _providers.Count == 0) return;

        var list = _providers.SelectMany(x => x.GetAll()).ToList();

        Data = new Dictionary<string, string>(list.Count);

        foreach (var item in list)
        {
            Data[item.Key] = item.Value;
        }
    }
}