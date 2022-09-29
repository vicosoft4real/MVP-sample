using MediatR;

namespace Application.Features.AgreementManagement.Requests;

public record UpdateAgreementRequest(
    Guid Id,
    DateTimeOffset EffectiveDate,
    DateTimeOffset Expiration,
    decimal ProductPrice,
    decimal NewPrice,
    Guid ProductId,
    Guid UserId,
    Guid GroupId, bool Active) : IRequest<(bool Succeed, string[] Error)>;
