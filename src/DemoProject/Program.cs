using Microsoft.Extensions.Configuration;
using System;
using Yuya.Net.Configuration.MSNetFrameworkConfiguration;

namespace DemoProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddMSNetFrameworkConfiguration(c => c
                    .AddAppSettings("Demo1", "Demo2")
                    .AddConnectionStrings(x => x.Key.StartsWith("cs")))
                .Build();

            Console.WriteLine(conf.GetValue<string>("Demo1"));
        }
    }
}