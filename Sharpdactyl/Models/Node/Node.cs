using Newtonsoft.Json;
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
        public NodeDatum[] Data { get; set; }

        [JsonProperty("meta", Required = Required.Always)]
        public Meta Meta { get; set; }
    }
    public partial class Meta
    {
        [JsonProperty("pagination", Required = Required.Always)]
        public Pagination Pagination {get;set;}
    }

    public class Pagination
    {
       [JsonProperty("total", Required = Required.Always)]
       public string Total { get; set; }

       [JsonProperty("count", Required = Required.Always)]
       public int Count { get; set; }

       [JsonProperty("per_page", Required = Required.Always)]
       public int Per_page { get; set; }

       [JsonProperty("current_page", Required = Required.Always)]
       public int Current_page { get; set; }

       [JsonProperty("total_pages", Required = Required.Always)]
       public int Total_pages { get; set; }

    }
}
