using Microsoft.EntityFrameworkCore;

public class LennyDbContext : DbContext
{
    public DbSet<PicEntity> Pics => Set<PicEntity>();    
    public DbSet<ShowEntity> Shows => Set<ShowEntity>();
    public DbSet<VenueEntity> Venues => Set<VenueEntity>();
    public DbSet<BandEntity> Bands => Set<BandEntity>();
    
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
