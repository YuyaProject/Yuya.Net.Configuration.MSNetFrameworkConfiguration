using System.Collections.Generic;
using System.Configuration;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

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