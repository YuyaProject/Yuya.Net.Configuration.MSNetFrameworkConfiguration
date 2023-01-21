using System;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class ConnectionStringsForKeysReaderProvider : ConnectionStringsForFilterReaderProvider
{
    private readonly string[] _keys;

    public ConnectionStringsForKeysReaderProvider(
        string[] keys,
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
        _func = x => _keys.Contains(x.Key);
        _keys = keys;
    }
}