using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

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

        public IEnumerable<KeyValuePair<string, string>> GetSectionSettings(string sectionName)
        {
            var section = ConfigurationManager.GetSection(sectionName);
            var type = section.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(section);
                yield return new(property.Name, value?.ToString());
            }

        }
    }
}