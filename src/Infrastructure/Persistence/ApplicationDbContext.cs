using Application.Interface.Persistence;
using Core.Entity;
using Infrastructure.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    public DbSet<Agreement> Agreements { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgreementConfiguration).Assembly);
        modelBuilder.Entity<Group>().HasIndex(x => x.Code).IsUnique();
        modelBuilder.Entity<Product>().HasIndex(x => x.Number).IsUnique();
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var group1 = new Group("Product description", "AZE1234", true).SetId();
        var group2 = new Group("Group 2, description", "AZE1235", true).SetId();
        modelBuilder.Entity<Group>().HasData(new List<Group>(){
            group1,
            group2
        });

        modelBuilder
            .Entity<Product>()
            .HasData(new List<Product>
            {
                new Product("New product sample1", "09887654",true, 30.00M, group1.Id).SetId(),
                new Product("New product sample2", "09887653",true, 40.00M, group2.Id).SetId()
            });
    }

    public class RampDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}