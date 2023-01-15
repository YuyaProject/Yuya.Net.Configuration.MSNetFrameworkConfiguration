using Microsoft.Extensions.Configuration;
using System;
using System.Configuration.Assemblies;
using System.Runtime;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    public class MSNetFrameworkConfigurationSource : IConfigurationSource
    {

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new MSNetFrameworkConfigurationProvider();
    }
}
