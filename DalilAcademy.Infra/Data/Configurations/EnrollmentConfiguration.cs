using System;

using DalilAcademy.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DalilAcademy.Infra.Data.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique();
        builder.HasOne(i => i.Student).WithMany(s => s.Enrollments).HasForeignKey(i => i.StudentId);
        builder.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(i => i.CourseId);
        builder.Property(i => i.EnrollmentAt).HasDefaultValueSql("now()");

    }
}