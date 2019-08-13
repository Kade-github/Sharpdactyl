using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;
using Sharpdactyl.Models.Client;
using Sharpdactyl.Models.User;
using Sharpdactyl.Models.Node;
using System;

namespace Sharpdactyl
{
    public enum PowerSettings
    {
        start,
        stop,
        restart,
        kill
    }

    public class PClient
    {
        public string HostName { get; set; }
        public string ApiKey { get; set; }
        
        public PClient(string hostName, string apiKey)
        {
            ApiKey = apiKey;
            HostName = hostName;
        }

        #region Client Code
        public List<ServerDatum> GetServers()
        {
            List<ServerDatum> servers = new List<ServerDatum>();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<Server>(Get("client"), settings);
            foreach (ServerDatum s in model.Data)
            {
                servers.Add(s);
            }
            return servers;
        }

        public ServerDatum GetServerById(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ServerDatum>(Get("client/servers/" + id), settings);
        }

        public ServerUtil GetServerUsage(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ServerUtil>(Get("client/servers/" + id + "/utilization"), settings);
        }

        public bool SendSignal(string ServerId, PowerSettings signal)
        {
            var data = new NameValueCollection();
            data["signal"] = signal.ToString();
            if (Post("client/servers/" + ServerId + "/power", data) != "")
                return false;
            else
                return true;
        }

        public bool PostCMDCommand(string ServerId, string command)
        {
            var data = new NameValueCollection();
            data["command"] = command;
            if (Post("client/servers/" + ServerId + "/command", data) != "")
                return false;
            else
                return true;
        }
        #endregion

        #region User Code (Aka admin Api)

        public List<UserDatum> Admin_GetUsers()
        {
            List<UserDatum> usDatas = new List<UserDatum>();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<User>(Get("application/users"), settings);
            foreach (UserDatum s in model.Data)
            {
                usDatas.Add(s);
            }
            return usDatas;
        }

        public UserDatum Admin_GetUserByExternalId(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<UserDatum>(Get("application/users/external/" + id), settings);
        }

        public UserDatum Admin_CreateUser(string username, string email, string first, string last, string password)
        {
            var data = new NameValueCollection();
            data["username"] = username;
            data["email"] = email;
            data["first_name"] = first;
            data["last_name"] = last;
            data["password"] = password;
            return JsonConvert.DeserializeObject<UserDatum>(Post("application/users", data));
        }

        public UserDatum Admin_EditUser(string userId, string username, string email, string first, string last, string password)
        {
            var data = new NameValueCollection();
            data["username"] = username;
            data["email"] = email;
            data["first_name"] = first;
            data["last_name"] = last;
            data["password"] = password;
            return JsonConvert.DeserializeObject<UserDatum>(Patch("application/users/" + userId, data));
        }

        public void Admin_DeleteUser(string userId) => Delete("application/users/" + userId);

        public List<NodeDatum> Admin_GetNodes()
        {
            List<NodeDatum> nodes = new List<NodeDatum>();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<Node>(Get("application/nodes"), settings);
            foreach (NodeDatum s in model.Data)
            {
                nodes.Add(s);
            }
            return nodes;
        }

        public NodeDatum Admin_GetNodeById(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<NodeDatum>(Get("application/nodes/" + id), settings);
        }

        public List<ServerDatum> Admin_GetServers()
        {
            // May take awhile depending on ur specs.
            List<ServerDatum> servers = new List<ServerDatum>();
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var model = JsonConvert.DeserializeObject<Server>(Get("application/servers"), settings);
            foreach (ServerDatum s in model.Data)
            {
                servers.Add(s);
            }
            return servers;
        }

        public ServerDatum Admin_GetServerById(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ServerDatum>(Get("application/servers/" + id), settings);
        }

        public ServerDatum Admin_GetServerByExternalId(string id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            return JsonConvert.DeserializeObject<ServerDatum>(Get("application/servers/" + id), settings);
        }

        public void Admin_CreateServer(ServerDatum srv)
        {
            ServerDatum srva = new ServerDatum();
            srva.Attributes.Description = "A new server!";
            srva.Attributes.feature_limits = new FeatureLimits() { Allocations = 0, Databases = 0 };
            srva.Attributes.Limits = new Limits() { Cpu = 200, Disk = 2000, Io = 56, Memory = 2048 };
            srva.Attributes.Name = "New Server!";
            srva.Attributes.Uuid = new Guid().ToString();
            var data = JsonConvert.SerializeObject(srv);
            PostJSON("application/servers/", data);
        }

        public void Admin_BanServerById(string id)
        {
            Post("application/servers/" + id + "/suspend", null);
        }

        public void Admin_UnBanServerById(string id)
        {
            Post("application/servers/" + id + "/unsuspend", null);
        }

        public void Admin_ReinstallServerById(string id)
        {
            Post("application/servers/" + id + "/reinstall", null);
        }

        public void Admin_RebuildServerById(string id)
        {
            Post("application/servers/" + id + "/rebuild", null);
        }

        public void Admin_DeleteServerById(string id, bool force = false)
        {
            if (!force)
                Delete("application/servers/" + id);
            else
                Delete("application/servers/" + id + "/force");
        }

        #endregion

        private void Delete(string query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HostName + "/api/" + query);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Method = "DELETE";
            request.Headers["Authorization"] = "Bearer " + ApiKey;
            request.ContentType = "application/json";
            request.Accept = "Application/vnd.pterodactyl.v1+json";
        }

        private string Patch(string query, NameValueCollection data)
        {
            var wb = new WebClient();

            wb.Headers.Add("Authorization", "Bearer " + ApiKey);
            wb.Headers.Add("Accept", "Application/vnd.pterodactyl.v1+json");

            var response = wb.UploadValues(HostName + "/api/" + query, "PATCH", data);
            string responseInString = Encoding.UTF8.GetString(response);

            return responseInString;
        }

        private string Post(string query, NameValueCollection data)
        {
            var wb = new WebClient();

            wb.Headers.Add("Authorization", "Bearer " + ApiKey);
            wb.Headers.Add("Accept", "Application/vnd.pterodactyl.v1+json");

            var response = wb.UploadValues(HostName + "/api/" + query, "POST", data);
            string responseInString = Encoding.UTF8.GetString(response);

            return responseInString;
        }

        private string PostJSON(string query, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(HostName + "/api/" + query);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var result = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private string Get(string query)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HostName + "/api/" + query);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            request.Headers["Authorization"] = "Bearer " + ApiKey;
            request.ContentType = "application/json";
            request.Accept = "Application/vnd.pterodactyl.v1+json";
            string json = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
    }
}
