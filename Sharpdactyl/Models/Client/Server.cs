using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sharpdactyl.Models.Client
{
    public class Limits
    {
        public int Memory { get; set; }
        public int Swap { get; set; }
        public int Disk { get; set; }
        public int Io { get; set; }
        public int Cpu { get; set; }
    }

    public class FeatureLimits
    {
        public int Databases { get; set; }
        public int Allocations { get; set; }
    }

    public class Attributes
    {
        public bool Server_owner { get; set; }
        public string Identifier { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Limits Limits { get; set; }
        public FeatureLimits feature_limits { get; set; }
    }

    public class ServerDatum
    {
        public Attributes Attributes { get; set; }
    }

    public class Server
    {
        public List<ServerDatum> Data { get; set; }
    }
}
