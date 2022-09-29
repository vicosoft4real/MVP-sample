using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interface.Persistence;

public interface IApplicationDbContext
{
    DbSet<Agreement> Agreements { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}