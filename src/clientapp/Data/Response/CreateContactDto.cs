namespace clientapp.Data.Response;

public class CreateContactDto
{
    public Guid ContactId { get; set; }
    public Guid? AddressId { get; set; }
}