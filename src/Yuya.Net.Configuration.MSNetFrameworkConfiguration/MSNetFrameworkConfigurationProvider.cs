using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Yuya.Net.Configuration.MSNetFrameworkConfiguration
{
    public class MSNetFrameworkConfigurationProvider : ConfigurationProvider
    {

        public override void Load()
        {
            var data = System.Configuration.ConfigurationManager.AppSettings.Keys
                .Cast<string>()
                .ToDictionary(x => x, x => System.Configuration.ConfigurationManager.AppSettings[x]);


            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 0)
            {
                foreach (ConnectionStringSettings key in System.Configuration.ConfigurationManager.ConnectionStrings)
                {
                    data.Add("ConnectionStrings:" + key.Name, key.ConnectionString);
                }
            }

            Data = data;
        }
    }
}
