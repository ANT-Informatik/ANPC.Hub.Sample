namespace clientapp.Data.Response;

public class AccountDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Name { get; set; }

    public List<AddressDto>? Addresses { get; set; }

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