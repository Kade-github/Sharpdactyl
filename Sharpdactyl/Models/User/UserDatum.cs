using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdactyl.Models.User
{
    public partial class UserDatum
    {
        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes
        {
            get;
            set;
        }
    }

    public class Attributes
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty("external_id", Required = Required.AllowNull)]
        public object ExternalId
        {
            get;
            set;
        }

        [JsonProperty("uuid", Required = Required.Always)]
        public Guid Uuid
        {
            get;
            set;
        }

        [JsonProperty("username", Required = Required.Always)]
        public string Username
        {
            get;
            set;
        }

        [JsonProperty("email", Required = Required.Always)]
        public string Email
        {
            get;
            set;
        }

        [JsonProperty("first_name", Required = Required.Always)]
        public string FirstName
        {
            get;
            set;
        }

        [JsonProperty("last_name", Required = Required.Always)]
        public string LastName
        {
            get;
            set;
        }

        [JsonProperty("language", Required = Required.Always)]
        public string Language
        {
            get;
            set;
        }

        [JsonProperty("root_admin", Required = Required.Always)]
        public bool RootAdmin
        {
            get;
            set;
        }

        [JsonProperty("2fa", Required = Required.Always)]
        public bool The2Fa
        {
            get;
            set;
        }

        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt
        {
            get;
            set;
        }

        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt
        {
            get;
            set;
        }
    }
}
