using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasker.Domain.BoardAggregate.Repositories;
using Tasker.Domain.TaskAggregate.Repositories;
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

    services.AddDbContext<IdentityDbContext>(options => 
      options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")!));
    
    services.AddDbContext<ApplicationDbContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!,
      x => x.MigrationsHistoryTable("_EfMigrations", "public")));

    services.AddIdentity<IdentityUser, IdentityRole>(
      options => {
          options.SignIn.RequireConfirmedAccount = false;
          options.Password.RequireDigit = true;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
          options.Password.RequiredLength = 0;
          options.Password.RequiredUniqueChars = 0;
      }
    )
    .AddEntityFrameworkStores<IdentityDbContext>();

    services.ConfigureApplicationCookie(options =>
    {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        //options.Cookie.Expiration 
    
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.SlidingExpiration = true;
        //options.ReturnUrlParameter=""
    });
    
    services.AddScoped<IBoardRepository, BoardRepository>();
    services.AddScoped<ITaskRepository, TaskRepository>();
  
    return services;
  }
}