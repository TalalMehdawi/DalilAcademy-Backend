using DalilAcademy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DalilAcademy.Infra.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
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
            if (context.Set<Instructor>().Any()) return;

            var Talal = new Instructor{FullName = "Talal Mehdawi"};
            var Sara = new Instructor { FullName = "Sara Hamed" };
            
            context.Set<Course>().AddRange(
                new Course{ Title = "C# Fundamentals" ,Price = 55.5m ,Instructor = Talal},
                new Course{ Title = "Python" ,Price = 60.5m ,Instructor = Sara}
                );

            context.SaveChanges();
        });
    }
}