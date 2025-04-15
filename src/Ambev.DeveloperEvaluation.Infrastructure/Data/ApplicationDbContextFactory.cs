using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ambev.DeveloperEvaluation.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true) // evita erro se não houver
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? "Host=localhost;Database=developer_evaluation;Username=developer;Password=ev@luAt10n";

            optionsBuilder.UseNpgsql(connectionString,
                x => x.MigrationsAssembly("Ambev.DeveloperEvaluation.Infrastructure"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
