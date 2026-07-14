using Microsoft.EntityFrameworkCore;
public class ShowRepository : IShowRepository
{
    private readonly LennyDbContext _context;    

    public ShowRepository(LennyDbContext context)
    {
        _context = context;       
    }

    public async Task<IEnumerable<ShowEntity>> GetAll()
    {
        return await _context.Shows
        .Include(v => v.Venue)
        .OrderByDescending(s => s.Date)
        .ToListAsync();
    }

    public async Task<ShowEntity> Get(int id)
    {
        return await _context.Shows
        .Where(s=>s.Id == id)
        .Include(v => v.Venue)
        .FirstAsync();
    }

    public async Task Delete(ShowEntity showEntity)
    {
        _context.Remove(showEntity);
    }

    public async Task AddShow(ShowEntity showEntity)
    {
        _context.Add(showEntity);              
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<bool> ForEditSaveChangesAsync(ShowEntity showEntity)
    {
        _context.Entry(showEntity).State = EntityState.Modified;
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<IEnumerable<VenueEntity>> GetVenues()
    {
        return await _context.Venues
        .OrderBy(v => v.Name)
        .ToListAsync();
    }
     public async Task<VenueEntity> GetVenue(int id)
    {
        return await _context.Venues
        .Where(s=>s.Id == id)
        .FirstAsync();
    }
   public async Task AddVenue(VenueEntity venueEntity)
    {
        _context.Venues.Add(venueEntity);              
    }

    public async Task DeleteVenue(VenueEntity venueEntity)
    {
        _context.Remove(venueEntity);
    }

    public async Task<IEnumerable<BandEntity>> GetBands()
    {
        return await _context.Bands
        .OrderBy(v => v.Name)
        .ToListAsync();
    }
     public async Task<BandEntity> GetBand(int id)
    {
        return await _context.Bands
        .Where(s=>s.Id == id)
        .FirstAsync();
    }
   public async Task AddBand(BandEntity bandEntity)
    {
        _context.Bands.Add(bandEntity);              
    }

    public async Task DeleteBand(BandEntity bandEntity)
    {
        _context.Remove(bandEntity);
    }

}