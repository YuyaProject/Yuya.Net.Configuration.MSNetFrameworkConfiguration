using Microsoft.Extensions.Configuration;
using System;
using Yuya.Net.Configuration.MSNetFrameworkConfiguration;

namespace DemoProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var newConfig = System.Configuration.ConfigurationManager.GetSection("Demo");

            var conf = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddMSNetFrameworkConfiguration(c => c
                    .AddAppSettings("Demo1", "Demo2", "RabbitMQ:Host")
                    .AddAppSettings(x=>x.Key.StartsWith("RabbitMQ"))
                    .AddConnectionStrings(x => x.Key.StartsWith("cs")))
                .Build();

            Console.WriteLine(conf.GetValue<string>("Demo1"));

            var rabbitMQSettings = conf.GetRequiredSection("RabbitMQ").Get<RabbitMQConnectionSettings>();

            Console.WriteLine("Host     : " + rabbitMQSettings.Host);
            Console.WriteLine("Port     : " + rabbitMQSettings.Port);
            Console.WriteLine("UserName : " + rabbitMQSettings.UserName);
            Console.WriteLine("Password : " + rabbitMQSettings.Password);
        }
    }
}