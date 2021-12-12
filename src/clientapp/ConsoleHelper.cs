using clientapp.Data;
using clientapp.Data.Request;

namespace clientapp;

public static class ConsoleHelper
{
    public static Guid TenantId()
    {
        while (true)
        {
            Console.Write("TenantId: ");
            var tenantIdString = Console.ReadLine();
            if (string.IsNullOrEmpty(tenantIdString) || !Guid.TryParse(tenantIdString, out var tenantId))
            {
                Console.Write("Invalid TenantId, retry? (y/n): ");
                var retry = Console.ReadLine();

                if (retry != "y")
                    Environment.Exit(1);
            }
            else
            {
                return tenantId;
            }
        }
    }

    public static Uri HubApiUri()
    {
        while (true)
        {
            Console.Write("Url HUB-API: ");
            var hubApiUrl = Console.ReadLine();
            if (string.IsNullOrEmpty(hubApiUrl) || !Uri.TryCreate(hubApiUrl, UriKind.Absolute, out var uri))
            {
                Console.Write("Invalid HUB-API url, retry? (y/n): ");
                var retry = Console.ReadLine();

                if (retry != "y")
                    Environment.Exit(1);
            }
            else
            {
                return uri;
            }
        }
    }

    public static string ObjectType()
    {
        while (true)
        {
            Console.Write("Object ([Account] a / [Contact] c / [Affiliation] aff): ");
            var selectedObject = Console.ReadLine();

            if (selectedObject != "a" && selectedObject != "aff" && selectedObject != "c")
            {
                Console.Write("Invalid object, retry? (y/n): ");
                var retry = Console.ReadLine();

                if (retry != "y")
                    Environment.Exit(1);
            }
            else
            {
                return selectedObject;
            }
        }
    }

    public static object? HubRequest(Guid tenantId, string selectedObject)
    {
        switch (selectedObject)
        {
            case "a":
                return CreateAccount(tenantId);
            case "c":
                return CreateContact(tenantId);
            //case "aff":
            //    return CreateAffiliation();
            default:
                return null;
        }
    }

    private static CreateAccountDto CreateAccount(Guid tenantId)
    {
        var accountType = AccountType.None;
        while (accountType == AccountType.None)
        {
            Console.Write("Type (o [Organization] / h [Household]: ");
            var selectedAccountType = Console.ReadLine();

            switch (selectedAccountType)
            {
                case "h":
                    accountType = AccountType.Household;
                    break;
                case "o":
                    accountType = AccountType.Organization;
                    break;
                default:
                    Console.WriteLine($"Invalid type {selectedAccountType}!");
                    break;
            }
        }

        var selectedName = string.Empty;
        while (string.IsNullOrEmpty(selectedName))
        {
            Console.Write("Name: ");
            selectedName = Console.ReadLine();
        }

        Console.Write("Address [format: street, postal code, city, state, country]: ");
        var selectedStreet = Console.ReadLine();
        var street = string.Empty;
        var postalCode = string.Empty;
        var city = string.Empty;
        var state = string.Empty;
        var country = string.Empty;

        if (!string.IsNullOrEmpty(selectedStreet))
        {
            var selectedStreetParts = selectedStreet.Split(',');
            street = selectedStreetParts[0];
            if (selectedStreetParts.Length > 1)
                postalCode = selectedStreetParts[1];
            if (selectedStreetParts.Length >= 2)
                city = selectedStreetParts[2];
            if (state.Length >= 3)
                state = selectedStreetParts[3];
            if (selectedStreetParts.Length >= 4)
                country = selectedStreetParts[4];
        }

        return new CreateAccountDto(
            selectedName,
            tenantId,
            accountType,
            address: new AddressDto(
                street,
                postalCode,
                city,
                state,
                country));
    }

    private static CreateOrUpdateContactDto CreateContact(Guid tenantId)
    {
        Guid selectedAccountId = default;
        var selectedAccountIdString = string.Empty;
        while (string.IsNullOrEmpty(selectedAccountIdString))
        {
            Console.WriteLine("Account (Id): ");
            selectedAccountIdString = Console.ReadLine();
            if (Guid.TryParse(selectedAccountIdString, out var accountId))
            {
                selectedAccountId = accountId;
                break;
            }

            Console.WriteLine("Please provide correct AccountId!");
        }

        var selectedFirstName = string.Empty;
        while (string.IsNullOrEmpty(selectedFirstName))
        {
            Console.WriteLine("First Name: ");
            selectedFirstName = Console.ReadLine();
        }

        var selectedLastName = string.Empty;
        while (string.IsNullOrEmpty(selectedLastName))
        {
            Console.WriteLine("Last Name: ");
            selectedLastName = Console.ReadLine();
        }

        Console.WriteLine("Address [format: street, postal code, city, state, country]: ");
        var selectedStreet = Console.ReadLine();
        var street = string.Empty;
        var postalCode = string.Empty;
        var city = string.Empty;
        var state = string.Empty;
        var country = string.Empty;

        if (!string.IsNullOrEmpty(selectedStreet))
        {
            var selectedStreetParts = selectedStreet.Split(',');
            street = selectedStreetParts[0];
            if (selectedStreetParts.Length > 1)
                postalCode = selectedStreetParts[1];
            if (selectedStreetParts.Length >= 2)
                city = selectedStreetParts[2];
            if (state.Length >= 3)
                state = selectedStreetParts[3];
            if (selectedStreetParts.Length >= 4)
                country = selectedStreetParts[4];
        }

        return new CreateOrUpdateContactDto(
            tenantId,
            selectedAccountId,
            firstName: selectedFirstName,
            lastName: selectedLastName,
            address: new AddressDto(
                street,
                postalCode,
                city,
                state,
                country));
    }

    public static string HubApiKey()
    {
        while (true)
        {
            Console.Write("API key: ");
            var apiKey = Console.ReadLine();
            if (string.IsNullOrEmpty(apiKey))
            {
                Console.Write("Invalid API key, retry? (y/n): ");
                var retry = Console.ReadLine();

                if (retry != "y")
                    Environment.Exit(1);
            }
            else
            {
                return apiKey;
            }
        }
    }
}