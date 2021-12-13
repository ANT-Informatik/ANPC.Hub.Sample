using System.Text.Json;
using clientapp.Data.Request;
using clientapp.Refit;
using Refit;
using StackExchange.Redis;

namespace clientapp;

internal class HubClient
{
    private readonly IHubClient hubClient;

    internal HubClient(Uri hubUri, string apiKey, Guid tenantId)
    {
        var connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:6379");
        var database = connectionMultiplexer.GetDatabase(1);

        var correlationId = Guid.NewGuid().ToString();
        var httpClient = new HttpClient
        {
            BaseAddress = hubUri
        };
        httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        httpClient.DefaultRequestHeaders.Add("x-tenant-id", tenantId.ToString());
        httpClient.DefaultRequestHeaders.Add("x-correlation-id", correlationId);

        database.StringSetAsync(correlationId, DateTime.UtcNow.ToLongDateString()).Wait();

        hubClient = RestService.For<IHubClient>(httpClient, new RefitSettings(new SystemTextJsonContentSerializer(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })));
    }

    internal async Task CallAndOutputAsync(object hubRequest)
    {
        if (hubRequest is CreateAccountDto createAccountDto)
        {
            var response = await hubClient.CreateAccountAsync(createAccountDto);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("HUB-API call failed!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("========================");
            Console.WriteLine("Account created");
            Console.WriteLine($"AccountId: {response.Content!.AccountId}");
            Console.WriteLine($"AddressId: {response.Content!.AddressId}");
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.ResetColor();
        }


        if (hubRequest is CreateOrUpdateContactDto createContactDto)
        {
            var response = await hubClient.CreateContactAsync(createContactDto);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("HUB-API call failed!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("========================");
            Console.WriteLine("Contact created");
            Console.WriteLine($"ContactId: {response.Content!.ContactId}");
            Console.WriteLine($"AddressId: {response.Content!.AddressId}");
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}