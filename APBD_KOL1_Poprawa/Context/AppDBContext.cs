using APBD_KOL1_Poprawa.EfConfigrations;
using APBD_KOL1_Poprawa.Models;
using Microsoft.EntityFrameworkCore;
using Task = APBD_KOL1_Poprawa.Models.Task;

namespace APBD_KOL1_Poprawa.Context;

public class AppDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Access> Accesses { get; set; }
    
    public AppDBContext() {}
    
    public AppDBContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEfConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectEfConfiguration());
        modelBuilder.ApplyConfiguration(new TaskEfConfiguration());
        modelBuilder.ApplyConfiguration(new AccessEfConfiguration());
    }
}