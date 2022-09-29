namespace Application.Features.AgreementManagement.Query;

public record AgreementByIdResponse
{
    public Guid Id { get; init; }
    public string EffectiveDate { get; init; }

    public string Expiration { get; init; }

    public decimal ProductPrice { get; init; }

    public decimal NewPrice { get; init; }
    public Guid ProductId { get; init; }
    public string UserId { get; init; }
    public Guid GroupId { get; init; }
    public bool Active { get; init; }
}