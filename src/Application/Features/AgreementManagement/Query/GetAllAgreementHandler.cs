using Application.Interface.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AgreementManagement.Query;

public class GetAllAgreementHandler: IRequestHandler<GetAllAgreementQuery,List<AgreementResponse>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllAgreementHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<List<AgreementResponse>> Handle(GetAllAgreementQuery request, CancellationToken cancellationToken)
    {
        var agreement = _applicationDbContext.Agreements
            .Include(x=>x.Product)
            .Include(x=>x.User)
            .Include(x=>x.Group)
            .Where(x=>!x.IsDeleted)
            .Select(x => new AgreementResponse
        {
            EffectiveDate = x.EffectiveDate,
            OldPrice = x.ProductPrice,
            NewPrice = x.NewPrice,
            GroupCode = x.Group.Code,
            ProductNumber = x.Product.Number,
            Username = x.User.UserName,
            Id = x.Id,
            ExpirationDate = x.Expiration

        });
        return await agreement.ToListAsync(cancellationToken);
    }
}