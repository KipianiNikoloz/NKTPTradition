using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext: DbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Tradition> Traditions { get; set; }
    public DbSet<Region> Regions { get; set; }

    public DataContext(DbContextOptions<DataContext> options): base(options) { }
    
}