using Application.Interface.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product;

public class GetAllProductHandler: IRequestHandler<GetAllProductQuery, List<GetProductResponse>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllProductHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<List<GetProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Products.Select(x => new GetProductResponse
        {
            Active = x.Active,
            Description = x.Description,
            Id = x.Id,
            Number = x.Number,
            Price = x.Price,
            GroupId = x.GroupId
        }).ToListAsync(cancellationToken);
    }
}