using MediatR;

namespace Application.Features.AgreementManagement.Query;

public record GetAgreementById(Guid Id): IRequest<AgreementByIdResponse>;