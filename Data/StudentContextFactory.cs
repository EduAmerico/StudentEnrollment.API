using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudentEnrollment.API.Data
{
    public class StudentContextFactory : IDesignTimeDbContextFactory<StudentContext>
    {
        public StudentContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));

            return new StudentContext(optionsBuilder.Options);
        }
    }
}
