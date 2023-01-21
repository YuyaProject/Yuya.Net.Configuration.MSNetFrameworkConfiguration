using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;

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

public interface IConfigurationReaderProvider
{
    IEnumerable<KeyValuePair<string, string>> GetAll();
}

public class AppSettingsReaderProvider : IConfigurationReaderProvider
{
    public IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
        {
            yield return new(key, System.Configuration.ConfigurationManager.AppSettings[key]);
        }
    }
}

public class ConnectionStringsReaderProvider : IConfigurationReaderProvider
{
    public IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (ConnectionStringSettings key in System.Configuration.ConfigurationManager.ConnectionStrings)
        {
            yield return new("ConnectionStrings:" + key.Name, key.ConnectionString);
        }
    }
}