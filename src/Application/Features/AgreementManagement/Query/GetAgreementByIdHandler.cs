using Application.Interface.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.AgreementManagement.Query;

public class GetAgreementByIdHandler : IRequestHandler<GetAgreementById, AgreementByIdResponse?>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAgreementByIdHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<AgreementByIdResponse?> Handle(GetAgreementById request, CancellationToken cancellationToken)
    {
        var agreement = _applicationDbContext.Agreements
            .Include(x=>x.Product)
            .Include(x=>x.Group)
            .Select(x => new AgreementByIdResponse
            {
                Id = x.Id,
                EffectiveDate = x.EffectiveDate.ToString("MM/dd/yyyy"),
                Expiration = x.Expiration.ToString("MM/dd/yyyy"),
                ProductPrice = x.ProductPrice,
                NewPrice = x.NewPrice,
                ProductId = x.ProductId,
                UserId = x.UserId,
                GroupId = x.GroupId,
                Active = x.Active

            });
        return await agreement.FirstOrDefaultAsync(x=>x.Id==request.Id,cancellationToken);
    }
}