using Application.Interface.Persistence;
using Core.Entity;
using MediatR;

namespace Application.Features.AgreementManagement.Requests;

/// <summary>
/// Handler for creating new agreement
/// </summary>
public class CreateAgreementHandler : IRequestHandler<CreateAgreementRequest, (bool Succeed, string CreatedId, string[]Errors)>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateAgreementHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    /// <summary>
    /// Create new agreement
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>(bool Succeed, string CreatedId, string[] Errors)</returns>
    public async Task<(bool Succeed, string CreatedId, string[] Errors)> Handle(CreateAgreementRequest request, CancellationToken cancellationToken)
    {
        var validator = AgreementRequestValidation.Create();
        var validate = await validator.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid) return (false, String.Empty, validate.Errors.Select(x => x.ErrorMessage).ToArray());
        var agreement = Agreement.CreateAgreement(
            request.EffectiveDate,
            request.Expiration,
            request.ProductPrice,
            request.NewPrice,
            request.ProductId,
            request.UserId.ToString(),
            request.GroupId,
            request.Active);
        _applicationDbContext.Agreements.Add(agreement);

        return (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0, agreement.Id.ToString(), Array.Empty<string>());
    }

   
}