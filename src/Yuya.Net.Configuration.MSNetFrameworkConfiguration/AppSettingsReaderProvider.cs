using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsReaderProvider : ConfigurationReaderProviderBase
{
    public AppSettingsReaderProvider(IConfigurationManagerService configurationManagerService = null) 
        : base(configurationManagerService)
    {
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll() 
        => _configurationManagerService.GetAllAppSettings();
}