using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsForFilterReaderProvider : AppSettingsReaderProvider
{
    private readonly Func<KeyValuePair<string, string>, bool> _func;

    public AppSettingsForFilterReaderProvider(Func<KeyValuePair<string, string>, bool> keys)
    {
        _func = keys;
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (var key in base.GetAll().Where(_func))
        {
            yield return key;
        }
    }
}