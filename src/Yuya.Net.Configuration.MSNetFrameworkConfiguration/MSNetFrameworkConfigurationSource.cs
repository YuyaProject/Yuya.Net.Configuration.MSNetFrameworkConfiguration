using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class MSNetFrameworkConfigurationSource : IConfigurationSource
{
    private readonly List<IConfigurationReaderProvider> _providers = new();

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new MSNetFrameworkConfigurationProvider(_providers);

    private MSNetFrameworkConfigurationSource AddProvider(IConfigurationReaderProvider provider)
    {
        _providers.Add(provider);
        return this;
    }

    public MSNetFrameworkConfigurationSource AddAppSettings()
        => AddProvider(new AppSettingsReaderProvider());

    public MSNetFrameworkConfigurationSource AddAppSettings(params string[] keys)
        => AddProvider(new AppSettingsForKeysReaderProvider(keys));

    public MSNetFrameworkConfigurationSource AddAppSettings(Func<KeyValuePair<string, string>, bool> filter)
        => AddProvider(new AppSettingsForFilterReaderProvider(filter));

    public MSNetFrameworkConfigurationSource AddConnectionStrings()
        => AddProvider(new ConnectionStringsReaderProvider());

    public MSNetFrameworkConfigurationSource AddConnectionStrings(params string[] keys)
        => AddProvider(new ConnectionStringsForKeysReaderProvider(keys));

    public MSNetFrameworkConfigurationSource AddConnectionStrings(Func<KeyValuePair<string, string>, bool> filter)
        => AddProvider(new ConnectionStringsForFilterReaderProvider(filter));

    public MSNetFrameworkConfigurationSource AddSection(string sectionName,
                                                        Func<KeyValuePair<string, string>, bool> filter = null,
                                                        string sectionNamePrefix = null)
        => AddProvider(new SectionForFilterReaderProvider(sectionName, filter, sectionNamePrefix));

}