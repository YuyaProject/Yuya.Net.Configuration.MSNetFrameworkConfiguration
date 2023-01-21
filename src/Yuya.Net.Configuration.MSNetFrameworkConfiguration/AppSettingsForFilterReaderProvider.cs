using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsForFilterReaderProvider : ConfigurationReaderProviderBase
{
    protected Func<KeyValuePair<string, string>, bool> _func;

    public AppSettingsForFilterReaderProvider(
        Func<KeyValuePair<string, string>, bool> func,
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
        => _func = func;

    protected AppSettingsForFilterReaderProvider(
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
        => _configurationManagerService.GetAllAppSettings().Where(_func);
}