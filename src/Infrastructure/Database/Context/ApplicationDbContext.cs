using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tasking.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
  private readonly IConfiguration _configuration;

  public ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options, 
    IConfiguration configuration) : base(options)
  {
    _configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"),
        builder => builder.MigrationsAssembly("Infrastructure"));
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}