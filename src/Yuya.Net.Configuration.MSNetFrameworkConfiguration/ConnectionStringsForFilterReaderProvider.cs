using System;
using System.Collections.Generic;
using System.Configuration;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class ConnectionStringsForFilterReaderProvider : ConnectionStringsReaderProvider
{

    private readonly Func<KeyValuePair<string, string>, bool> _func;

    public ConnectionStringsForFilterReaderProvider(Func<KeyValuePair<string, string>, bool> keys)
    {
        _func = keys;
    }


    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (ConnectionStringSettings key in System.Configuration.ConfigurationManager.ConnectionStrings)
        {
            if (_func(new(key.Name, key.ConnectionString)))
                yield return new("ConnectionStrings:" + key.Name, key.ConnectionString);
        }
    }
}