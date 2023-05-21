using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    internal class ConfigurationManagerService : IConfigurationManagerService
    {
        private static readonly string[] inheritedPropertyNames = new[] {
            "SectionInformation",
            "LockAttributes",
            "LockAllAttributesExcept",
            "LockElements",
            "LockAllElementsExcept",
            "LockItem",
            "ElementInformation",
            "CurrentConfiguration"
            };

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

        public IEnumerable<KeyValuePair<string, string>> GetSectionSettings(string sectionName, bool addSectionInheritProperties = false)
        {
            var section = ConfigurationManager.GetSection(sectionName);
            var type = section.GetType();
            var properties = type.GetProperties();

            if (!addSectionInheritProperties)
            {
                properties = properties.Where(x => !inheritedPropertyNames.Contains(x.Name)).ToArray();
            }

            foreach (var property in properties)
            {
                var value = property.GetValue(section);
                if (value != null)
                {
                    var valueType = value.GetType();
                    if (!valueType.IsValueType && !valueType.IsEnum && value is not string)
                    {
                        var valueProperties = valueType.GetProperties();

                        foreach (var valueProperty in valueProperties)
                        {
                            var valueValue = valueProperty.GetValue(value);
                            yield return new(property.Name + ":" + valueProperty.Name, valueValue?.ToString());
                        }
                    }
                }
                yield return new(property.Name, value?.ToString());
            }
        }
    }
}