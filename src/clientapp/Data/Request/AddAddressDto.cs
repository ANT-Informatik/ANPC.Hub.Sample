namespace clientapp.Data.Request;

public class AddAddressDto
{
    public AddAddressDto(
        Guid tenantId,
        bool excludeFromUpdates,
        bool isAmbiguous,
        bool isDefaultAddress,
        bool isVerified,
        string? name = null,
        string? addressType = null,
        string? administrativeArea = null,
        string? state = null,
        string? street = null,
        string? street2 = null,
        string? city = null,
        string? county = null,
        string? country = null,
        string? district = null,
        string? postalCode = null,
        string? verificationStatus = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        DateTime? verifiedDate = null)
    {
        TenantId = tenantId;
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

    public Guid TenantId { get; }

    public bool ExcludeFromUpdates { get; }
    public bool IsAmbiguous { get; }
    public bool IsDefaultAddress { get; }
    public bool IsVerified { get; }

    public string? Name { get; }
    public string? AddressType { get; }
    public string? AdministrativeArea { get; }
    public string? State { get; }
    public string? Street { get; }
    public string? Street2 { get; }
    public string? City { get; }
    public string? County { get; }
    public string? Country { get; }
    public string? District { get; }
    public string? PostalCode { get; }
    public string? VerificationStatus { get; }

    public DateTime? StartDate { get; }
    public DateTime? EndDate { get; }
    public DateTime? VerifiedDate { get; }
}