![image](https://cdn.discordapp.com/attachments/515033167850373122/610725914271285250/pterodactyl_logo_transparent.png)
# Sharpdactyl
## The C# API Wrapper for the Pterodacty Game Panel

# Installation
## Nugget:
`Install-Package Kade.Sharpdactyl`
[Nugget Link](https://www.nuget.org/packages/Kade.Sharpdactyl/)
## Other
Dowload from releases [here](https://github.com/KadePcGames/Sharpdactyl/releases/latest)

# Api Docs
## Client
### Servers (1/1)
To get started lets make a API Instance
```csharp
PClient client = new PClient("host","apiKey");
```
Now lets get all the servers
```csharp
foreach (ServerDatum srv in client.GetServers())
{
  Console.WriteLine(srv.Attributes.Name);
}
```
Output:
```
Server #1
Server #2
Server #3
Server #4
```
## Admin API
### Servers (1/3)
Lets get all the servers with an admin api key,
**and suspend them all!**
```csharp
foreach (ServerDatum srv in client.Admin_GetServers())
{
  client.Admin_BanServerById(srv.Attributes.Identifier);
}
```
### Users (2/3)
How about we delete all the users?
```csharp
foreach (UserDatum usr in client.Admin_GetUsers())
{
  client.Admin_DeleteUser(usr.Attributes.Identifier);
}
```
### Nodes (3/3)
Lets see all of the nodes as well!
```csharp
foreach (NodeDatum node in client.Admin_GetNodes())
{
  Console.WriteLine("Node: " + node.Attributes.Name);
}
```
## Other
Theres a lot more stuff in the api, which is way too much to explain in one readme. So might make a full documentation soon!.
