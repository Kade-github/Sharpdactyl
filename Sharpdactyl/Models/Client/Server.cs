using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sharpdactyl.Models.Client
{
    public class Limits
    {
        [JsonProperty("memory", Required = Required.Always)]
        public int Memory { get; set; }
        [JsonProperty("swap", Required = Required.Always)]
        public int Swap { get; set; }
        [JsonProperty("disk", Required = Required.Always)]
        public int Disk { get; set; }
        [JsonProperty("io", Required = Required.Always)]
        public int Io { get; set; }
        [JsonProperty("cpu", Required = Required.Always)]
        public int Cpu { get; set; }
    }
    public class FeatureLimits
    {
        [JsonProperty("databases", Required = Required.Always)]
        public int Databases { get; set; }
        [JsonProperty("allocations", Required = Required.Always)]
        public int Allocations { get; set; }
    }
    public class Container
    {
        public string Startup_command { get; set; }
        public string Image { get; set; }
        public bool Installed { get; set; }
        public Dictionary<string,string> Environment { get; set; }
    }
    public class Deployment
    {
        [JsonProperty("locations", Required = Required.Always)]
        public List<int> Locations { get; set; }
        [JsonProperty("dedicated_ip", Required = Required.Always)]
        public bool Dedicated_Ip { get; set; }
        [JsonProperty("port_range", Required = Required.Always)]
        public List<string> Port_range {get;set;}
    }
    public class Attributes
    {
        [JsonProperty("external_id")]
        public string External_Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("limits")]
        public Limits Limits { get; set; }
        [JsonProperty("skip_scripts")]
        public bool Skip_Scripts { get; set; }
        [JsonProperty("feature_limits")]
        public FeatureLimits Feature_Limits { get; set; }
        [JsonProperty("user")]
        public int User { get; set; }
        [JsonProperty("node")]
        public int Node { get; set; }
        [JsonProperty("allocation")]
        public int Allocation { get; set; }
        [JsonProperty("nest")]
        public int Nest { get; set; }
        [JsonProperty("egg")]
        public int Egg { get; set; }
        [JsonProperty("pack")]
        public int? Pack { get; set; }
        [JsonProperty("docker_image")]
        public string Docker_image { get; set; }
        [JsonProperty("container")]
        public Container Container { get; set; }
        [JsonProperty("startup")]
        public string Startup { get; set; }
        [JsonProperty("environment")]
        public Dictionary<string, string> Environment { get; set; }
        [JsonProperty("deploy")]
        public Deployment Deploy { get; set; }
        [JsonProperty("start_on_completion")]
        public bool Start_On_Completion { get; set; }
    }
    public class ServerDatum
    {
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }
    public class Server
    {
        public List<ServerDatum> Data { get; set; }
    }
}
