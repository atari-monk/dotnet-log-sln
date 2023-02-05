using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Log.Data;

public class LogDbContext
    : DbContextDbConfig
{
    public DbSet<Category>? Category { get; set; }

	public DbSet<Place>? Place { get; set; }

	public DbSet<Task>? Task { get; set; }

	public DbSet<LogModel>? Log { get; set; }
    
    protected override void SeedData(ModelBuilder builder)
    {
    }
}