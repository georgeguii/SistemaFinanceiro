using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Entities.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Expense> Expense { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<FinancialSystem> FinancialSystem { get; set; }
    public DbSet<UserFinancialSystem> UserFinancialSystem { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Environment.GetEnvironmentVariable("FINANCIAL_SYSTEM_CONNECTION_STRING");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().ToTable("AspNetUsers")
            .HasKey(t => t.Id);

        base.OnModelCreating(builder);
    }
}
