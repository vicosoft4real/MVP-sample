using Application.Interface.Persistence;
using MediatR;

namespace Application.Features.AgreementManagement.Requests;

public class UpdateAgreementHandler : IRequestHandler<UpdateAgreementRequest, (bool Succeed, string[]Error)>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateAgreementHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// Update agreement
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<(bool Succeed, string[] Error)> Handle(UpdateAgreementRequest request, CancellationToken cancellationToken)
    {
        var validation = AgreementUpdateValidation.Create();
        var validate = await validation.ValidateAsync(request, cancellationToken);
        if (!validate.IsValid)
        {
            return (false, validate.Errors.Select(x => x.ErrorMessage).ToArray());
        }
        var agreement = await _applicationDbContext.Agreements.FindAsync(request.Id);
        if (agreement == null) return (false, new[] { "Agreement not found" });
        agreement
            .SetEffectiveDate(request.EffectiveDate)
            .SetExpirationDate(request.Expiration)
            .SetProductPrice(request.ProductPrice)
            .SetNewPrice(request.NewPrice)
            .SetProductId(request.ProductId)
            .SetGroupId(request.GroupId)
            .SetUserId(request.UserId.ToString())
            .SetActive(request.Active);
        return (await _applicationDbContext.SaveChangesAsync(cancellationToken)> 0 , new string[]{});
    }
}