using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public interface IConfigurationReaderProvider
{
    IEnumerable<KeyValuePair<string, string>> GetAll();
}