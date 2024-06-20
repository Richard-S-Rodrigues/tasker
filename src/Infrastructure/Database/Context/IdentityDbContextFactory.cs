using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasker.Infrastructure.Context;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
  public IdentityDbContext CreateDbContext(string[] args)
  {
    var sourceDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
    var startupDirectory =  Path.Combine(sourceDirectory?.FullName!, "Web");
     
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(startupDirectory)
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddJsonFile("appsettings.local.Development.json", optional: true, reloadOnChange: true)
      .Build();
        
    var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
    optionsBuilder.UseNpgsql(configuration.GetConnectionString("IdentityConnection")!);

    return new IdentityDbContext(optionsBuilder.Options, configuration);
  }
}