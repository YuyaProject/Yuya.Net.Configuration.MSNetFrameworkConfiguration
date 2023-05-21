using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class SectionForFilterReaderProvider : ConfigurationReaderProviderBase
{
    protected Func<KeyValuePair<string, string>, bool> _filterFunction;
    protected string _sectionName;
    protected string _sectionNamePrefix;
    protected bool _addSectionInheritProperties = false;

    public SectionForFilterReaderProvider(
        string sectionName,
        Func<KeyValuePair<string, string>, bool> filterFunction = null,
        string sectionNamePrefix = null,
        bool addSectionInheritProperties = false,
        IConfigurationManagerService configurationManagerService = null)
        : base(configurationManagerService)
    {
        _sectionName = sectionName;
        _sectionNamePrefix = sectionNamePrefix ?? sectionName;
        _addSectionInheritProperties = addSectionInheritProperties;
        _filterFunction = filterFunction ?? (_ => true);
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
            return _configurationManagerService.GetSectionSettings(_sectionName, _addSectionInheritProperties)
                .Where(_filterFunction);
        }
        return _configurationManagerService.GetSectionSettings(_sectionName, _addSectionInheritProperties)
            .Where(_filterFunction)
            .Select(x => new KeyValuePair<string, string>($"{_sectionNamePrefix}:{x.Key}", x.Value));
    }
}