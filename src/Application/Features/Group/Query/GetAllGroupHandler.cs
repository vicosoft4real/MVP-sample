using Application.Interface.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Group.Query;

public class GetAllGroupHandler: IRequestHandler<GetAllGroupQuery, List<GetGroupResponse>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllGroupHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public async Task<List<GetGroupResponse>> Handle(GetAllGroupQuery query, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Groups.Select(x => new GetGroupResponse()
        {
            Id = x.Id,
            Code = x.Code,
            Description = x.Description,
            Active = x.Active
        }).ToListAsync(cancellationToken);
    }
}