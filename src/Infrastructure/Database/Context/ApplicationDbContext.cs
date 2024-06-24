using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tasker.Domain.BoardAggregate;

namespace Tasker.Infrastructure.Context;

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
      optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")!);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Board> Boards { get; set; } = null!;
  public DbSet<Domain.TaskAggregate.Task> Tasks { get; set; } = null!;
}