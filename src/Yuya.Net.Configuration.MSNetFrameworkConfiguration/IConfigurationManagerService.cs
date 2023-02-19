using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    public interface IConfigurationManagerService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAppSettings();
        IEnumerable<KeyValuePair<string, string>> GetAllConnectionStrings();
        IEnumerable<KeyValuePair<string, string>> GetSectionSettings(string sectionName);
    }
}