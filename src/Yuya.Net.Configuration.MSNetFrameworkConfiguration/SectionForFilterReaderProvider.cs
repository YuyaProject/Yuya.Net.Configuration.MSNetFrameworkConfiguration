using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class SectionForFilterReaderProvider : ConfigurationReaderProviderBase
{
    protected Func<KeyValuePair<string, string>, bool> _func;
    protected string _sectionName;
    protected string _sectionNamePrefix;

    public SectionForFilterReaderProvider(
        string sectionName,
        Func<KeyValuePair<string, string>, bool> func = null,
        string sectionNamePrefix = null,
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
        _sectionName = sectionName;
        _sectionNamePrefix = sectionNamePrefix ?? sectionName;
        _func = func ?? (_ => true);
    }

    protected SectionForFilterReaderProvider(
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
    }

    public override IEnumerable<KeyValuePair<string, string>> GetAll()
    {
        if(string.IsNullOrWhiteSpace(_sectionNamePrefix))
        {
            return _configurationManagerService.GetSectionSettings(_sectionName)
                .Where(_func);
        }
        return _configurationManagerService.GetSectionSettings(_sectionName)
            .Where(_func)
            .Select(x => new KeyValuePair<string, string>($"{_sectionNamePrefix}:{x.Key}", x.Value));
    }
}