using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sharpdactyl.Models.User.UserDataModel;

namespace Sharpdactyl.Models.User
{
    public partial class User
    {
        [JsonProperty("object", Required = Required.Always)]

        public string Object { get; set; }
        [JsonProperty("data", Required = Required.Always)]
        public UserDatum[] Data { get; set; }
    }
    
}
