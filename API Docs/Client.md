## Client Methods
### Get Client Servers
`PCient.GetServers();`
Returns
`List<ServerDatum>`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
foreach (ServerDatum srv in client.GetServers())
{
    Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
}
```
Output
```
Server #1@32e74e55
```
### Get server by ID
`PClient.GetServerById(string id);`
Returns
`ServerDatum`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srv = client.GetServerById(32e74e55);
Console.WriteLine(srv.Attributes.Name + @ + srv.Attributes.Identifer);
```
Output
```
Server #1@32e74e55
```
### Get Server Usage
`PClient.GetServerUsage(string id);`
Returns
`ServerUtil`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
ServerDatum srv = client.GetServerById(32e74e55);
ServerUtil srvU = client.GetServerUsage(srv.Attributes.Identifer);
Console.WriteLine(srvU.Attributes.Memory.Current +  MB Usage);
```
Output
```
2048 MB Usage
```
### Sending singals to servers
`PClient.SendSignal(string ServerId, PowerSettings signal);`
Returns
`bool`
Example
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
if (client.SendSignal(32e74e55, PowerSettings.start))
    Console.WriteLine(Signal Sent!);
else
    Console.WriteLine(Failed to send!);
```
### Post a CMD Command
`PClient.PostCMDCommand(string ServerId, string command);`
Returns
`bool`
```csharp
PClient client = new PClient(hostName, meowmeowmeow);
if (client.PostCMDCommand(32e74e55, say Hello!))
    Console.WriteLine(Command Sent!);
else
    Console.WriteLine(Command failed to send!);
```
