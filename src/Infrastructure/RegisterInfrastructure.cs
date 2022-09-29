using Application.Interface.Persistence;
using Core.Entity;
using Infrastructure.Persistence;
using Infrastructure.Seeder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class RegisterInfrastructure
{
    public static void AddInfrastructureServices(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString,x=>x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.ToString())));
        serviceCollection.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
        serviceCollection.AddScoped<IApplicationDbContext>(x => x.GetRequiredService<ApplicationDbContext>());
    }
}