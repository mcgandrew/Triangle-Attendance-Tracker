using Microsoft.EntityFrameworkCore;
using WsuTriangle.AttendanceTracker.Models;

namespace WsuTriangle.AttendanceTracker;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<BeefWellington> BeefWellingtons => Set<BeefWellington>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}