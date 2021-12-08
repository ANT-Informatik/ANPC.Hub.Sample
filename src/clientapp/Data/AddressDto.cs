namespace clientapp.Data;

public class AddressDto
{
    public AddressDto(
        string? street,
        string? postalCode,
        string? city,
        string? state,
        string? country,
        Guid? id = null)
    {
        Id = id;
        Street = street;
        PostalCode = postalCode;
        City = city;
        State = state;
        Country = country;
        IsDefaultAddress = true;
    }

    public bool IsDefaultAddress { get; }

    public Guid? Id { get; }
    public string? Street { get; }
    public string? PostalCode { get; }
    public string? City { get; }
    public string? State { get; }
    public string? Country { get; }
}