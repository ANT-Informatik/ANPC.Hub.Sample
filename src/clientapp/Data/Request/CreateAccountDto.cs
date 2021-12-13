namespace clientapp.Data.Request;

public class CreateAccountDto
{
    public CreateAccountDto(
        string name,
        Guid tenantId,
        AccountType type,
        int? numberOfEmployees = null,
        string? accountNumber = null,
        string? batchNumber = null,
        string? fax = null,
        string? formalGreeting = null,
        string? householdPhone = null,
        string? industry = null,
        string? informalGreeting = null,
        Guid? primaryContactId = null,
        string? phone = null,
        string? shippingCity = null,
        string? shippingCountry = null,
        string? shippingState = null,
        string? shippingStreet = null,
        string? shippingPostalCode = null,
        string? source = null,
        string? website = null,
        AddressDto? address = null)
    {
        Name = name;
        TenantId = tenantId;
        NumberOfEmployees = numberOfEmployees;
        AccountNumber = accountNumber;
        BatchNumber = batchNumber;
        Fax = fax;
        FormalGreeting = formalGreeting;
        HouseholdPhone = householdPhone;
        Industry = industry;
        InformalGreeting = informalGreeting;
        PrimaryContactId = primaryContactId;
        Phone = phone;
        Type = type;
        ShippingCity = shippingCity;
        ShippingCountry = shippingCountry;
        ShippingState = shippingState;
        ShippingStreet = shippingStreet;
        ShippingPostalCode = shippingPostalCode;
        Source = source;
        Website = website;
        Address = address;
    }

    public string Name { get; set; }
    public Guid TenantId { get; set; }
    public AccountType Type { get; set; }
    public AddressDto? Address { get; set; }

    public int? NumberOfEmployees { get; set; }

    public string? AccountNumber { get; set; }
    public string? BatchNumber { get; set; }
    public string? FormalGreeting { get; set; }
    public string? Industry { get; set; }
    public string? InformalGreeting { get; set; }
    public Guid? PrimaryContactId { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingCountry { get; set; }
    public string? ShippingState { get; set; }
    public string? ShippingStreet { get; set; }
    public string? ShippingPostalCode { get; set; }
    public string? Source { get; set; }
    public string? Fax { get; set; }
    public string? HouseholdPhone { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
}