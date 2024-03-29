﻿using System;

namespace DemoProject
{
    public class RabbitMQConnectionSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string[] ClusterHostsAndPorts { get; set; } = Array.Empty<string>();
    }
}