using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DalilAcademy.Core.Entities;
namespace DalilAcademy.Infra.Data.Configurations;

public class CourseConfiguration :IEntityTypeConfiguration<Course>
{

    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c =>c.Id);
        builder.Property(c =>c.Title).IsRequired().HasMaxLength(200);
        builder.Property(c=>c.Price).HasPrecision(10,2);
        builder.HasIndex(c=>c.Title).IsUnique();
        builder.HasOne(c=>c.Instructor)
        .WithMany(i=>i.Courses)
        .HasForeignKey(c=>c.InstructorId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}
