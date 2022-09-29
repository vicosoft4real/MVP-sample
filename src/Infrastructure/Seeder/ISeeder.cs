using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Seeder;

public interface ISeeder
{
    /// <summary>
    /// Seeds the asynchronous.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <returns></returns>
    Task SeedAsync(IApplicationBuilder app);
}