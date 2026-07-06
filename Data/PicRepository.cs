using Microsoft.EntityFrameworkCore;

public class PicRepository : IPicRepository
{
    private readonly LennyDbContext _context;

    public PicRepository(LennyDbContext context)
    {
        _context = context;
    }

    public async Task<PicDto> Add(PicDto pic)
    {
        // mapping plugin?
        var entity = new PicEntity
        {
            Filename = pic.Filename,
            DisplayOrder = pic.DisplayOrder
        };
        _context.Pics.Add(entity);
        await _context.SaveChangesAsync();

        return new PicDto(entity.Id, entity.Filename, entity.DisplayOrder);
    }

    public async Task<PicDto> Delete(int id)
    {
        var entity = await _context.Pics.SingleOrDefaultAsync(p => p.Id == id);
        if (entity == null)
        {
            throw new ArgumentException($"Trying to delete pic: entity with ID {id} not found.");
        }
        _context.Pics.Remove(entity);
        await _context.SaveChangesAsync();
        return new PicDto(entity.Id, entity.Filename, entity.DisplayOrder);
    }

    public async Task<PicDto> Get(int id)
    {
        var e = await _context.Pics.SingleOrDefaultAsync(p => p.Id == id);
        if (e == null)
        {
            return null;
        }
        return new PicDto(e.Id, e.Filename, e.DisplayOrder);
    }

    public async Task<List<PicDto>> GetAll()
    {
        return await _context.Pics
            .OrderBy(p => p.DisplayOrder)
            .Select(p => new PicDto(p.Id, p.Filename, p.DisplayOrder))
            .ToListAsync();
    }

    public Task<PicDto> Update(PicDto pic)
    {
        throw new NotImplementedException();
    }
}