using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Domain.TaskAggregate.Repositories;
using Tasker.Domain.UserAggregate.Repositories;
using Tasker.Infrastructure.Context;
using Tasker.Infrastructure.Database.Repositories;

namespace Tasker.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddDbContext<ApplicationDbContext>(options => 
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!));
    
    services.AddDbContext<ApplicationDbContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!,
      x => x.MigrationsHistoryTable("_EfMigrations", "public")));
    
    services.AddScoped<IBoardRepository, BoardRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ITaskRepository, TaskRepository>();
  
    return services;
  }
}