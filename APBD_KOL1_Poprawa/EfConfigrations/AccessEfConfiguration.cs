using APBD_KOL1_Poprawa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOL1_Poprawa.EfConfigrations;

public class AccessEfConfiguration : IEntityTypeConfiguration<Access>
{
    public void Configure(EntityTypeBuilder<Access> builder)
    {
        builder.HasKey(a => a.IdAccess);
        builder.Property(a => a.IdAccess).ValueGeneratedOnAdd();
    }
}