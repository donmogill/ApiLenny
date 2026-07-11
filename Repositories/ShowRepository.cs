using Microsoft.EntityFrameworkCore;
public class ShowRepository : IShowRepository
{
    private readonly LennyDbContext _context;    

    public ShowRepository(LennyDbContext context)
    {
        _context = context;       
    }

    public async Task<List<ShowEntity>> GetAll()
    {
        return await _context.Shows
        .Include(v => v.Venue)
        .OrderBy(s => s.Date)
        .ToListAsync();
    }


}