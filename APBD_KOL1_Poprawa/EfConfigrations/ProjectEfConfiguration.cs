using APBD_KOL1_Poprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOL1_Poprawa.EfConfigrations;

public class ProjectEfConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.IdProject);
        builder.Property(p => p.IdProject).ValueGeneratedOnAdd();

        builder.HasMany(p => p.accessNavigation)
            .WithOne(a => a.projectNavigation)
            .HasForeignKey(a => a.IdProject);

        builder.HasMany(p => p.TaskNavigation)
            .WithOne(t => t.projectNavigation)
            .HasForeignKey(t => t.IdProject);
    }
}