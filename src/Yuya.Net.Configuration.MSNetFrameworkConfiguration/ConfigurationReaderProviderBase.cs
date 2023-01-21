using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public abstract class ConfigurationReaderProviderBase : IConfigurationReaderProvider
{
    protected readonly IConfigurationManagerService _configurationManagerService;

    protected ConfigurationReaderProviderBase(IConfigurationManagerService configurationManagerService = null)
    {
        _configurationManagerService = configurationManagerService ?? new ConfigurationManagerService();
    }

    public abstract IEnumerable<KeyValuePair<string, string>> GetAll();
}