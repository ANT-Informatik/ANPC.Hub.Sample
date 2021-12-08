// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

var cc = new AccountCreatedDto(Guid.NewGuid(), "Test", Guid.NewGuid(), AccountType.Household);
var b = JsonSerializer.Serialize(cc, new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    IgnoreNullValues = true,
    WriteIndented = false
});
var a = new
{
    action = "All",
    payload = cc
};

var p = JsonSerializer.Serialize(a, new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    IgnoreNullValues = true,
    WriteIndented = false
});


Console.WriteLine(p);

Console.WriteLine(ComputeHash("Test", b));
Console.ReadLine();

static string ComputeHash(string webHookKey, string payloadJson)
{
    using var sha256Hash = SHA256.Create();
    var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{webHookKey}{payloadJson}"));
    var builder = new StringBuilder();
    foreach (var jsonByte in bytes)
    {
        builder.Append(jsonByte.ToString("x2"));
    }

    return builder.ToString();
}

public class WebHookContent<T>
{
    public WebHookContent(string action, T payload)
    {
        Action = action;
        Payload = payload;
    }

    public T Payload { get; set; }
    public string Action { get; set; }
}

public class AddressDto
{
    public AddressDto(
        Guid id,
        bool? excludeFromUpdates,
        bool? isAmbiguous,
        bool? isDefaultAddress,
        bool? isVerified,
        string? name,
        string? addressType,
        string? administrativeArea,
        string? state,
        string? street,
        string? street2,
        string? city,
        string? county,
        string? country,
        string? district,
        string? postalCode,
        string? verificationStatus,
        DateTime? startDate,
        DateTime? endDate,
        DateTime? verifiedDate)
    {
        Id = id;
        Name = name;
        ExcludeFromUpdates = excludeFromUpdates;
        IsAmbiguous = isAmbiguous;
        IsDefaultAddress = isDefaultAddress;
        IsVerified = isVerified;
        AddressType = addressType;
        AdministrativeArea = administrativeArea;
        State = state;
        Street = street;
        Street2 = street2;
        City = city;
        County = county;
        Country = country;
        District = district;
        PostalCode = postalCode;
        VerificationStatus = verificationStatus;
        StartDate = startDate;
        EndDate = endDate;
        VerifiedDate = verifiedDate;
    }

    public Guid Id { get; set; }

    public bool? ExcludeFromUpdates { get; set; }
    public bool? IsAmbiguous { get; set; }
    public bool? IsDefaultAddress { get; set; }
    public bool? IsVerified { get; set; }

    public string? Name { get; set; }
    public string? AddressType { get; set; }
    public string? AdministrativeArea { get; set; }
    public string? State { get; set; }
    public string? Street { get; set; }
    public string? Street2 { get; set; }
    public string? City { get; set; }
    public string? County { get; set; }
    public string? Country { get; set; }
    public string? District { get; set; }
    public string? PostalCode { get; set; }
    public string? VerificationStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? VerifiedDate { get; set; }
}

public class AccountCreatedDto
{
    public AccountCreatedDto(
        Guid id,
        string name,
        Guid tenantId,
        AccountType type,
        AddressDto? address = null,
        int? numberOfEmployees = null,
        string? accountNumber = null,
        string? batchNumber = null,
        string? fax = null,
        string? formalGreeting = null,
        string? householdPhone = null,
        string? industryName = null,
        string? informalGreeting = null,
        Guid? primaryContactId = null,
        string? phone = null,
        string? shippingCity = null,
        string? shippingCountry = null,
        string? shippingState = null,
        string? shippingStreet = null,
        string? shippingPostalCode = null,
        string? sourceName = null,
        string? website = null)
    {
        Id = id;
        Name = name;
        TenantId = tenantId;
        Type = type;
        Address = address;
        NumberOfEmployees = numberOfEmployees;
        AccountNumber = accountNumber;
        BatchNumber = batchNumber;
        Fax = fax;
        FormalGreeting = formalGreeting;
        HouseholdPhone = householdPhone;
        Industry = industryName;
        InformalGreeting = informalGreeting;
        PrimaryContactId = primaryContactId;
        Phone = phone;
        ShippingCity = shippingCity;
        ShippingCountry = shippingCountry;
        ShippingState = shippingState;
        ShippingStreet = shippingStreet;
        ShippingPostalCode = shippingPostalCode;
        Source = sourceName;
        Website = website;
    }

    public string? BillingCity { get; set; }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TenantId { get; set; }
    public AccountType Type { get; set; }
    public AddressDto? Address { get; set; }

    public Guid? PrimaryContactId { get; set; }

    public int? NumberOfEmployees { get; set; }

    public string? AccountNumber { get; set; }
    public string? BatchNumber { get; set; }
    public string? Fax { get; set; }
    public string? FormalGreeting { get; set; }
    public string? HouseholdPhone { get; set; }
    public string? Industry { get; set; }
    public string? InformalGreeting { get; set; }
    public string? Phone { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingCountry { get; set; }
    public string? ShippingState { get; set; }
    public string? ShippingStreet { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? Source { get; set; }
    public string? Website { get; set; }
}

public enum AccountType
{
    Household,
    Organization
}