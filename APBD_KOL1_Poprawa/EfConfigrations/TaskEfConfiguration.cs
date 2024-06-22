using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = APBD_KOL1_Poprawa.Models.Task;

namespace APBD_KOL1_Poprawa.EfConfigrations;

public class TaskEfConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(t => t.IdTask);
        builder.Property(t => t.IdTask).ValueGeneratedOnAdd();
    }
}