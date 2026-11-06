using DalilAcademy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DalilAcademy.Infra.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) 
    {
        builder.HasKey(s=>s.Id);
        builder.HasIndex(s=>s.Email).IsUnique();
        builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
    }
}