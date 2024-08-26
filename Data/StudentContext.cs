using Microsoft.EntityFrameworkCore;
using StudentEnrollment.API.Models;

namespace StudentEnrollment.API.Data
{
    public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}
}
