namespace clientapp.Data.Request;

public class UpdateAffiliationDto
{
    public UpdateAffiliationDto(
        Guid tenantId,
        Guid accountId,
        Guid contactId,
        bool isPrimary,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? relatedOpportunityContactRole = null,
        string? role = null,
        string? description = null,
        string? status = null)
    {
        TenantId = tenantId;
        AccountId = accountId;
        ContactId = contactId;
        IsPrimary = isPrimary;
        StartDate = startDate;
        EndDate = endDate;
        RelatedOpportunityContactRole = relatedOpportunityContactRole;
        Role = role;
        Description = description;
        Status = status;
    }

    public Guid TenantId { get; }
    public Guid AccountId { get; }
    public Guid ContactId { get; }
    public bool IsPrimary { get; }

    public DateTime? EndDate { get; }
    public DateTime? StartDate { get; }

    public string? RelatedOpportunityContactRole { get; }
    public string? Role { get; }
    public string? Description { get; }
    public string? Status { get; }
}