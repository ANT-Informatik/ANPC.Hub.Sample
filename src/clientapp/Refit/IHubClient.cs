using clientapp.Data.Request;
using clientapp.Data.Response;
using Refit;

namespace clientapp.Refit;

public interface IHubClient
{
    [Get("/api/account/{id}")]
    Task<ApiResponse<AccountDto>> GetAccountAsync([Query] Guid id, [Query] Guid tenantId);

    [Post("/api/account")]
    Task<ApiResponse<Data.Response.CreateAccountDto>> CreateAccountAsync([Body] Data.Request.CreateAccountDto createAccountDto);

    [Post("/api/account/{id}")]
    Task<ApiResponse<Data.Response.UpdateAccountDto>> UpdateAccountAsync([Query] Guid id, [Body] Data.Request.UpdateAccountDto updateAccountDto);

    [Post("/api/account/{id}/address")]
    Task<ApiResponse<Data.Response.AddAddressDto>> AddAddressAsync([Query] Guid id, [Body] Data.Request.AddAddressDto addAddressDto);

    [Post("/api/affiliation")]
    Task<ApiResponse<Data.Response.AddAffiliationDto>> AddAffiliationAsync([Body] Data.Request.AddAffiliationDto addAffiliationDto);

    [Post("/api/account/{id}/affiliation/{affiliationId}")]
    Task UpdateAccountAffiliationAsync([Query] Guid id, Guid affiliationId, [Body] UpdateAffiliationDto addAffiliationDto);

    [Post("/api/account/{id}/address/{addressId}")]
    Task UpdateAddressAsync([Query] Guid id, Guid addressId, [Body] UpdateAddressDto updateAddressDto);

    [Get("/api/contact/{id}")]
    Task<ApiResponse<ContactDto>> GetContactAsync([Query] Guid id, [Query] Guid tenantId);

    [Post("/api/contact")]
    Task<ApiResponse<CreateContactDto>> CreateContactAsync([Body] CreateOrUpdateContactDto createContactDto);

    [Post("/api/contact/{id}")]
    Task UpdateContactAsync([Query] Guid id, [Body] CreateOrUpdateContactDto updateContactDto);
}