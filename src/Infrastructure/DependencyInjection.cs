using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasker.Infrastructure.Context;

namespace Tasker.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration
  )
  {
    services.AddDbContext<ApplicationDbContext>(options => 
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    
    services.AddDbContext<ApplicationDbContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
      x => x.MigrationsHistoryTable("_EfMigrations", "public")));
    
    return services;
  }
}