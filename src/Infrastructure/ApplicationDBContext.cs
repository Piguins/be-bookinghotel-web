using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext() {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var basePath = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory) ?? "", "Api");
        var builder = new ConfigurationBuilder()
            // .SetBasePath(Directory.GetCurrentDirectory())
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var configuration = builder.Build();
        var connString = configuration.GetConnectionString("MyStoreDB");
        optionsBuilder.UseSqlServer(connString);

        base.OnConfiguring(optionsBuilder);
    }
}
