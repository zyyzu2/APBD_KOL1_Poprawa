using APBD_KOL1_Poprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOL1_Poprawa.EfConfigrations;

public class UserEfConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.IdUser);
        builder.Property(u => u.IdUser).ValueGeneratedOnAdd();

        builder.HasMany(u => u.accessNavigation)
            .WithOne(a => a.userNavigation)
            .HasForeignKey(a => a.IdUser);

        builder.HasMany(u => u.projectNavigation)
            .WithOne(p => p.defaultAssigneeNavigation)
            .HasForeignKey(p => p.IdDefaultAssignee);

        builder.HasMany(u => u.taskAssigneNavigation)
            .WithOne(t => t.assigneeNavigation)
            .HasForeignKey(t => t.IdAssignee);

        builder.HasMany(u => u.taskReporterNavigation)
            .WithOne(t => t.reporterNavigation)
            .HasForeignKey(t => t.IdReporter);
    }
}