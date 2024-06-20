using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tasker.Infrastructure.Context;

public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
  private readonly IConfiguration _configuration;

  public IdentityDbContext(
    DbContextOptions<IdentityDbContext> options,
    IConfiguration configuration) : base(options)
  {
    _configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql(_configuration.GetConnectionString("IdentityConnection")!);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }
}