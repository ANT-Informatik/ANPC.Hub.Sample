using System.Text.Json;
using clientapp.Data.Request;
using clientapp.Refit;
using Refit;

namespace clientapp;

internal class HubClient
{
    private readonly IHubClient hubClient;

    internal HubClient(Uri hubUri)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = hubUri
        };
        httpClient.DefaultRequestHeaders.Add("x-api-key", "ftVrsLQCyYYKjY2YLaE6gB6pqO0XMgzPNH7g3Mfew30nGdmlMibYcpO7KU7p7YP7");

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