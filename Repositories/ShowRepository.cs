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

    public async Task AddShow(ShowEntity showEntity)
    {
        _context.Add(showEntity);              
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }

    public async Task<IEnumerable<VenueEntity>> GetVenues()
    {
        return await _context.Venues
        .OrderBy(v => v.Name)
        .ToListAsync();
    }


}