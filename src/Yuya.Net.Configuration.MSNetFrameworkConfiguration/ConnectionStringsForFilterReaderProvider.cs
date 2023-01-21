using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class ConnectionStringsForFilterReaderProvider : ConnectionStringsReaderProvider
{
    protected Func<KeyValuePair<string, string>, bool> _func;

    public ConnectionStringsForFilterReaderProvider(
        Func<KeyValuePair<string, string>, bool> keys,
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
        => _func = keys;

    protected ConnectionStringsForFilterReaderProvider(
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
        => _configurationManagerService.GetAllConnectionStrings()
            .Where(_func)
            .Select(ChangeKey);
}