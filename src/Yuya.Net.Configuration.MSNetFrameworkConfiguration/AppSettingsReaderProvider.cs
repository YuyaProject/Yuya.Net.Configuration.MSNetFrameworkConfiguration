using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class AppSettingsReaderProvider : IConfigurationReaderProvider
{
    public virtual IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        foreach (string key in System.Configuration.ConfigurationManager.AppSettings.Keys)
        {
            yield return new(key, System.Configuration.ConfigurationManager.AppSettings[key]);
        }
    }
}