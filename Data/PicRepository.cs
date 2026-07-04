using Microsoft.EntityFrameworkCore;

public class PicRepository : IPicRepository
{
    private readonly LennyDbContext _context;

    public PicRepository(LennyDbContext context)
    {
        _context = context;
    }

    public Task<List<PicDto>> Add(PicDto pic)
    {
        throw new NotImplementedException();
    }

    public Task<List<PicDto>> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PicDto>> Get(int id)
    {
        var e = await _context.Pics.SingleOrDefaultAsync(p => p.Id == id);
        if (e == null)
        {
            return null;
        }
        return new List<PicDto> { new PicDto(e.Id, e.Filename, e.DisplayOrder) };
    }

    public async Task<List<PicDto>> GetAll()
    {
        return await _context.Pics
            .OrderBy(p => p.DisplayOrder)
            .Select(p => new PicDto(p.Id, p.Filename, p.DisplayOrder))
            .ToListAsync();
    }

    public Task<List<PicDto>> Update(PicDto pic)
    {
        throw new NotImplementedException();
    }
}