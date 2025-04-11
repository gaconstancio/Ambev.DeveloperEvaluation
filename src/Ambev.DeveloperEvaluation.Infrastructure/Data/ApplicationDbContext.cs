using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Infrastructure.Data;

/// <summary>
/// Represents the database context for the application.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to configure the context.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the sales in the database.
    /// </summary>
    public DbSet<Sale> Sales { get; set; }

    /// <summary>
    /// Gets or sets the users in the database.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Configures the model for the database.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Sale entity
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
            entity.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(s => s.IsCancelled).HasDefaultValue(false);
        });

        // Configure User entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
        });
    }
}


