namespace clientapp.Data.Response;

public class ContactDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AccountId { get; set; }

    public string? Reference { get; set; }

    public Guid? PrimaryAffiliationId { get; set; }

    public bool AddressOverride { get; set; }
    public bool HasOptedOutOfEmail { get; set; }
    public bool HasOptedOutOfFax { get; set; }
    public bool IsPrimaryContact { get; set; }
    public bool Deceased { get; set; }
    public bool DoNotCall { get; set; }
    public bool DoNotContact { get; set; }

    public AddressDto? Address { get; set; }

    public DateTime? Birthdate { get; set; }
    public string? AlternateEmail { get; set; }
    public string? BatchNumber { get; set; }
    public string? Department { get; set; }
    public string? Email { get; set; }
    public string? Fax { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? HomeEmail { get; set; }
    public string? HomePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? Phone { get; set; }
    public string? PreferredEmail { get; set; }
    public string? PreferredPhone { get; set; }
    public string? Salutation { get; set; }
    public string? Source { get; set; }
    public string? Title { get; set; }
    public string? WorkEmail { get; set; }
    public string? WorkPhone { get; set; }
}