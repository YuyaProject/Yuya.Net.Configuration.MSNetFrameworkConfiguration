using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Yuya.Net.Configuration.MSNetFrameworkConfiguration;

namespace DemoProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conf = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddMSNetFrameworkConfiguration()
                .Build();

            Console.WriteLine(conf.GetValue<string>("Demo1"));
        }
    }
}