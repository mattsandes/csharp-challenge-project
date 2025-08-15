using Microsoft.EntityFrameworkCore;
using StudyProject.Models;

namespace StudyProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Device> Device { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Device)
            .WithOne(u => u.User)
            .HasForeignKey<Device>(u => u.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Person)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.PersonId);
    }
}