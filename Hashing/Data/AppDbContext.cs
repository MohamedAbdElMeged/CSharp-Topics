using Hashing.Models;
using Microsoft.EntityFrameworkCore;

namespace Hashing.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(s => s.Id);
        modelBuilder.Entity<Student>().HasIndex(s => s.UserNameHashed);
        modelBuilder.Entity<Student>(b =>
        {
            b.Property(x => x.UserName).HasColumnType("nvarchar(max)");
            b.Property(x => x.UserNameHashed).HasMaxLength(64);
        });
    }
    public DbSet<Student> Students { get; set; }
    

    
}