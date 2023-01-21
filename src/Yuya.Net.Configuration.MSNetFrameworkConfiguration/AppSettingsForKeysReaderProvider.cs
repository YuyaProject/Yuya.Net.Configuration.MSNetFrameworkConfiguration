using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsForKeysReaderProvider : AppSettingsReaderProvider
{
    private readonly string[] _keys;

    public AppSettingsForKeysReaderProvider(string[] keys)
    {
        _keys = keys;
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (var key in base.GetAll().Where(x => _keys.Contains(x.Key)))
        {
            yield return key;
        }
    }
}
