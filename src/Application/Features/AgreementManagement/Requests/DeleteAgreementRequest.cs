using MediatR;

namespace Application.Features.AgreementManagement.Requests;

public record DeleteAgreementRequest(Guid Id): IRequest<(bool Succeeded, string[] Error)>;