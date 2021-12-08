namespace clientapp.Data.Response;

public class CreateAccountDto
{
    public Guid AccountId { get; set; }
    public Guid? AddressId { get; set; }
}