using Lab6DBFirstApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PagingandSortingApp.Data
{
    public class SampleContextFactory:IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DbConnection");
            builder.UseSqlServer(connectionString,b=>b.MigrationsAssembly("PagingandSortingApp"));

            return new AppDbContext(builder.Options);
        }
    }
}
