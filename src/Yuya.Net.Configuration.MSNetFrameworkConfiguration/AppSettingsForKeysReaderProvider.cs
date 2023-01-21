using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsForKeysReaderProvider : AppSettingsForFilterReaderProvider
{
    private readonly string[] _keys;

    public AppSettingsForKeysReaderProvider(string[] keys, IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
        _func = Check;
        _keys = keys;
    }

    private bool Check(KeyValuePair<string, string> item) => _keys.Contains(item.Key);
}