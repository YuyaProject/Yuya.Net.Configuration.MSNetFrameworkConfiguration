using System.Collections.Generic;
using System.Configuration;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    internal class ConfigurationManagerService : IConfigurationManagerService
    {
        public IEnumerable<KeyValuePair<string, string>> GetAllAppSettings()
        {
            foreach (string key in ConfigurationManager.AppSettings.Keys)
            {
                yield return new(key, ConfigurationManager.AppSettings[key]);
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllConnectionStrings()
        {
            foreach (ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                yield return new(item.Name, item.ConnectionString);
            }
        }
    }
}