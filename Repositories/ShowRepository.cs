using Microsoft.EntityFrameworkCore;
public class ShowRepository : IShowRepository
{
    private readonly LennyDbContext _context;    

    public ShowRepository(LennyDbContext context)
    {
        _context = context;       
    }

    public async Task<IEnumerable<Show>> GetAll()
    {
        return await _context.Shows
        .Include(v => v.Venue)
        .OrderByDescending(s => s.Date)
        .ToListAsync();
    }

    public async Task<Show> Get(int id)
    {
        return await _context.Shows
        .Where(s=>s.Id == id)
        .Include(v => v.Venue)
        .FirstAsync();
    }

    public async Task Delete(Show show)
    {
        _context.Remove(show);
    }

    public async Task AddShow(Show show)
    {
        _context.Add(show);              
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<bool> ForEditSaveChangesAsync(Show show)
    {
        _context.Entry(show).State = EntityState.Modified;
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<IEnumerable<Venue>> GetVenues()
    {
        return await _context.Venues
        .OrderBy(v => v.Name)
        .ToListAsync();
    }
     public async Task<Venue> GetVenue(int id)
    {
        return await _context.Venues
        .Where(s=>s.Id == id)
        .FirstAsync();
    }
   public async Task AddVenue(Venue venue)
    {
        _context.Venues.Add(venue);              
    }

    public async Task DeleteVenue(Venue venue)
    {
        _context.Remove(venue);
    }

    public async Task<IEnumerable<Band>> GetBands()
    {
        return await _context.Bands
        .Include(s=>s.Shows)
        .OrderBy(v => v.Name)
        .ToListAsync();
    }
     public async Task<Band> GetBand(int id)
    {
        return await _context.Bands
        .Where(s=>s.Id == id)
        .FirstAsync();
    }
   public async Task AddBand(Band band)
    {
        _context.Bands.Add(band);              
    }

    public async Task DeleteBand(Band band)
    {
        _context.Remove(band);
    }

}