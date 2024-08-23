using Microsoft.EntityFrameworkCore;
using StudentEnrollment.API.Models;

namespace StudentEnrollment.API.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.RA)
                .IsUnique();
            
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.CPF)
                .IsUnique();
        }
    }
}
