using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tasker.Infrastructure.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
  public ApplicationDbContext CreateDbContext(string[] args)
  {
    var sourceDirectory = Directory.GetParent(Directory.GetCurrentDirectory());
    var startupDirectory =  Path.Combine(sourceDirectory?.FullName!, "Web");
     
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(startupDirectory)
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddJsonFile("appsettings.local.Development.json", optional: true, reloadOnChange: true)
      .Build();
        
    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!);

    return new ApplicationDbContext(optionsBuilder.Options, configuration);
  }
}