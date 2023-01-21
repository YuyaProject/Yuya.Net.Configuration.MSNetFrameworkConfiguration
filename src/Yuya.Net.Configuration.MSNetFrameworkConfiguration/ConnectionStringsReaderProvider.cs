using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class ConnectionStringsReaderProvider : ConfigurationReaderProviderBase
{
    public ConnectionStringsReaderProvider(IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        return _configurationManagerService.GetAllConnectionStrings()
            .Select(ChangeKey);
    }

    protected static KeyValuePair<string, string> ChangeKey(KeyValuePair<string, string> item)
        => new("ConnectionStrings:" + item.Key, item.Value);
}