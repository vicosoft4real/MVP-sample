using Application.Interface.Persistence;
using MediatR;

namespace Application.Features.AgreementManagement.Requests;

public class DeleteAgreementHandler : IRequestHandler<DeleteAgreementRequest, (bool Succeeded, string[] Error)>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteAgreementHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// Handle delete
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<(bool Succeeded, string[] Error)> Handle(DeleteAgreementRequest request, CancellationToken cancellationToken)
    {
        var agreement = await _applicationDbContext.Agreements.FindAsync(request.Id);
        if (agreement == null) return (false, new[] { "Agreement not found" });

        agreement.SetIsDeleted(true);
        return (await _applicationDbContext.SaveChangesAsync(cancellationToken) > 0, new string[] { });
    }
}