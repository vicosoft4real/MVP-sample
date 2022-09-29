using Core.Entity;

namespace Application.Features.AgreementManagement.Query;

#nullable disable
public record AgreementResponse
{
    /// <summary>
    /// Agreement Id
    /// </summary>
    public Guid Id { get; init; }
    public string Username { get; init; }
    
    public string GroupCode { get; init; }
    
    public string ProductNumber { get; init; }

    public DateTimeOffset EffectiveDate { get; init; }

    public decimal NewPrice { get; init; }
    
    public decimal OldPrice { get; init; }

    public DateTimeOffset ExpirationDate { get; init; }

    public Core.Entity.Group Group { get; init; }
    
    public Core.Entity.Product Product { get; init; }

    public User User { get; init; }

    public bool Active { get; init; }
}