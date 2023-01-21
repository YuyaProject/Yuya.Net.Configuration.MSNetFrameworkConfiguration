using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Runtime;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration;

public class MSNetFrameworkConfigurationSource : IConfigurationSource
{
    private readonly List<IConfigurationReaderProvider> _providers = new();

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new MSNetFrameworkConfigurationProvider(_providers);



    public MSNetFrameworkConfigurationSource AddAppSettings()
    {
        _providers.Add(new AppSettingsReaderProvider());
        return this;
    }
    public MSNetFrameworkConfigurationSource AddConnectionStrings()
    {
        _providers.Add(new ConnectionStringsReaderProvider());
        return this;
    }
}
