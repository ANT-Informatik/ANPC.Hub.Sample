using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

Console.Write("WebHook Secret: ");
var secret = Console.ReadLine();
Console.WriteLine("");
Console.WriteLine("");
var builder = WebApplication.CreateBuilder(args);

builder.WebHost
    .UseUrls("http://*:5000;http://localhost:5001;");

var app = builder.Build();

app.MapPost("/", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
    var webHookJson = await reader.ReadToEndAsync();

    if (string.IsNullOrEmpty(webHookJson))
        return Results.BadRequest();

    var webHook = JObject.Parse(webHookJson);
    var sha256HashHeader = context.Request.Headers["X-SextantHub-Signature-256"];

    if (StringValues.Empty == sha256HashHeader)
        return Results.BadRequest();

    if (null == webHook["payload"])
        return Results.BadRequest();

    if (!IsHashValid(webHook["payload"]?.ToString(Formatting.None)!, sha256HashHeader))
        return Results.BadRequest();

    var connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
    var database = connectionMultiplexer.GetDatabase(1);


    Console.WriteLine("");
    Console.WriteLine($"WebHook received: {JObject.Parse(webHookJson).ToString(Formatting.Indented)}");

    if (!database.KeyExists(webHook["correlationId"]?.ToString()))
        return Results.Ok();

    Console.WriteLine($"WebHook coming from clientapp. CorrelationId:{webHook["correlationId"]}");
    return Results.Accepted();
});

app.Run();

bool IsHashValid(string payload, string hash)
{
    using var sha256Hash = SHA256.Create();
    var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{secret}{payload}"));
    var builder = new StringBuilder();
    foreach (var jsonByte in bytes)
    {
        builder.Append(jsonByte.ToString("x2"));
    }

    return hash.Equals(builder.ToString(), StringComparison.Ordinal);
}