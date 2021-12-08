namespace clientapp.Data.Request;

public class CreateOrUpdateContactDto
{
    public CreateOrUpdateContactDto(
        Guid tenantId,
        Guid accountId,
        bool? addressOverride = null,
        bool? hasOptedOutOfEmail = null,
        bool? hasOptedOutOfFax = null,
        bool? isPrimaryContact = null,
        bool? deceased = null,
        bool? doNotCall = null,
        bool? doNotContact = null,
        DateTime? birthdate = null,
        string? alternateEmail = null,
        string? batchNumber = null,
        string? department = null,
        string? email = null,
        string? fax = null,
        string? firstName = null,
        string? lastName = null,
        string? homeEmail = null,
        string? homePhone = null,
        string? mobilePhone = null,
        string? phone = null,
        string? preferredEmail = null,
        string? preferredPhone = null,
        Guid? primaryAffiliationId = null,
        string? salutation = null,
        string? source = null,
        string? title = null,
        string? workEmail = null,
        string? workPhone = null,
        AddressDto? address = null)
    {
        TenantId = tenantId;
        AccountId = accountId;
        AddressOverride = addressOverride;
        HasOptedOutOfEmail = hasOptedOutOfEmail;
        HasOptedOutOfFax = hasOptedOutOfFax;
        IsPrimaryContact = isPrimaryContact;
        Deceased = deceased;
        DoNotCall = doNotCall;
        DoNotContact = doNotContact;
        Birthdate = birthdate;
        AlternateEmail = alternateEmail;
        BatchNumber = batchNumber;
        Address = address;
        Department = department;
        Email = email;
        Fax = fax;
        FirstName = firstName;
        LastName = lastName;
        HomeEmail = homeEmail;
        HomePhone = homePhone;
        MobilePhone = mobilePhone;
        Phone = phone;
        PreferredEmail = preferredEmail;
        PreferredPhone = preferredPhone;
        PrimaryAffiliationId = primaryAffiliationId;
        Salutation = salutation;
        Source = source;
        Title = title;
        WorkEmail = workEmail;
        WorkPhone = workPhone;
    }

    public Guid TenantId { get; set; }
    public Guid AccountId { get; set; }

    public Guid? PrimaryAffiliationId { get; set; }

    public bool? AddressOverride { get; set; }
    public bool? HasOptedOutOfEmail { get; set; }
    public bool? HasOptedOutOfFax { get; set; }
    public bool? IsPrimaryContact { get; set; }
    public bool? Deceased { get; set; }
    public bool? DoNotCall { get; set; }
    public bool? DoNotContact { get; set; }

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

    public AddressDto? Address { get; set; }
}