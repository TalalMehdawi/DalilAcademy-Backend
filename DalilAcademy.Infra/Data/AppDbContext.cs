using DalilAcademy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DalilAcademy.Infra.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Course>Courses=>Set<Course>();
    public DbSet<Instructor>Instructors=>Set<Instructor>();
    public DbSet<Enrollment>Enrollments=>Set<Enrollment>();
    public DbSet<Student>Students=>Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof (AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            if (!context.Set<Instructor>().Any()) {

            var Talal = new Instructor{FullName = "Talal Mehdawi"};
            var Sara = new Instructor { FullName = "Sara Hamed" };
            
            context.Set<Course>().AddRange(
                new Course{ Title = "C# Fundamentals" ,Price = 55.5m ,Instructor = Talal},
                new Course{ Title = "Python" ,Price = 60.5m ,Instructor = Sara}
                );

            context.SaveChanges();
            }

            if (!context.Set<User>().Any())
            {
                var admin = new User
                {
                    Email = "admin@dalil.jo",
                    Role = Roles.Admin,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123")
                };
                context.Set<User>().Add(admin);
                context.SaveChanges();

            }
        });
    }
}