using Microsoft.EntityFrameworkCore;

public class LennyDbContext : DbContext
{
    public DbSet<Pic> Pics => Set<Pic>();    
    public DbSet<Show> Shows => Set<Show>();
    public DbSet<Venue> Venues => Set<Venue>();
    public DbSet<Band> Bands => Set<Band>();
    public DbSet<Video> Videos => Set<Video>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    
    public LennyDbContext(DbContextOptions<LennyDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        options.UseSqlite($"Data Source=lenny.db");        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData.Seed(modelBuilder);
    }

}
