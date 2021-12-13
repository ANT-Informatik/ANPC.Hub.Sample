// See https://aka.ms/new-console-template for more information

using clientapp;

Console.WriteLine("===============================================================");
Console.WriteLine("Sample Application for ANT Non Profit Cloud Integration");
Console.WriteLine("Hints:");
Console.WriteLine("- to add new contacts you need to create an account first");
Console.WriteLine("- not all fields are mapped, app can be extended for testing");
Console.WriteLine("- API client is created over Refit (https://github.com/reactiveui/refit)");
Console.WriteLine("===============================================================");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");

var exit = false;

var tenantId = ConsoleHelper.TenantId();
var apiKey = ConsoleHelper.HubApiKey();
var hubApiUri = ConsoleHelper.HubApiUri();

while (!exit)
{
    var objectType = ConsoleHelper.ObjectType();
    var hubRequest = ConsoleHelper.HubRequest(tenantId, objectType);
    var hubClient = new HubClient(hubApiUri, apiKey, tenantId);

    await hubClient.CallAndOutputAsync(hubRequest!);

    Console.Write("Exit (y/n): ");
    var exitString = Console.ReadLine();

    if (exitString == "y")
        exit = true;

    Console.Write("");
}