using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdactyl.Models.Node
{
    public partial class NodeDatum
    {
        [JsonProperty("object", Required = Required.Always)]
        public string Object { get; set; }

        [JsonProperty("attributes", Required = Required.Always)]
        public Attributes Attributes { get; set; }
    }

    public partial class Attributes
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("public", Required = Required.Always)]
        public bool Public { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty("location_id", Required = Required.Always)]
        public long LocationId { get; set; }

        [JsonProperty("fqdn", Required = Required.Always)]
        public string Fqdn { get; set; }

        [JsonProperty("scheme", Required = Required.Always)]
        public string Scheme { get; set; }

        [JsonProperty("behind_proxy", Required = Required.Always)]
        public bool BehindProxy { get; set; }

        [JsonProperty("maintenance_mode", Required = Required.Always)]
        public bool MaintenanceMode { get; set; }

        [JsonProperty("memory", Required = Required.Always)]
        public long Memory { get; set; }

        [JsonProperty("memory_overallocate", Required = Required.Always)]
        public long MemoryOverallocate { get; set; }

        [JsonProperty("disk", Required = Required.Always)]
        public long Disk { get; set; }

        [JsonProperty("disk_overallocate", Required = Required.Always)]
        public long DiskOverallocate { get; set; }

        [JsonProperty("upload_size", Required = Required.Always)]
        public long UploadSize { get; set; }

        [JsonProperty("daemon_listen", Required = Required.Always)]
        public long DaemonListen { get; set; }

        [JsonProperty("daemon_sftp", Required = Required.Always)]
        public long DaemonSftp { get; set; }

        [JsonProperty("daemon_base", Required = Required.Always)]
        public string DaemonBase { get; set; }

        [JsonProperty("created_at", Required = Required.Always)]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", Required = Required.Always)]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
