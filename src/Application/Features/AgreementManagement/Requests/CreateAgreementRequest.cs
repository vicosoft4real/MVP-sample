using MediatR;

namespace Application.Features.AgreementManagement.Requests;

public record CreateAgreementRequest
(DateTimeOffset EffectiveDate,
    DateTimeOffset Expiration,
    decimal ProductPrice,
    decimal NewPrice,
    Guid ProductId,
    Guid GroupId,
    bool Active) : IRequest<(bool Succeed, string CreatedId, string[]Errors)>
{
    public   Guid UserId { get; set; }
}