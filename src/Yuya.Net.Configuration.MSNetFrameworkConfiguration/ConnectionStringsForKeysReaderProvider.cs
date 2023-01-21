using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class ConnectionStringsForKeysReaderProvider : ConnectionStringsReaderProvider
{

    private readonly string[] _keys;

    public ConnectionStringsForKeysReaderProvider(string[] keys)
    {
        _keys = keys;
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (ConnectionStringSettings key in System.Configuration.ConfigurationManager.ConnectionStrings)
        {
            if (_keys.Contains(key.Name))
                yield return new("ConnectionStrings:" + key.Name, key.ConnectionString);
        }
    }
}
