using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdactyl.Models.Node
{
    public partial class Node
    {
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        [JsonProperty("data", Required = Required.Always)]
        public Datum[] Data { get; set; }

        [JsonProperty("meta", Required = Required.Always)]
        public Meta Meta { get; set; }
    }
}
