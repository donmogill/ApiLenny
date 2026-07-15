using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

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
        var entity = new Pic
        {
            Filename = pic.Filename,
            DisplayOrder = new PicService(this).GetNextDisplayOrder()
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
        var entity = await _context.Pics.SingleOrDefaultAsync(p => p.Id == id);
        if (entity == null)
        {
            throw new ArgumentException($"Trying to get pic: entity with ID {id} not found.");
        }
        return new PicDto(entity.Id, entity.Filename, entity.DisplayOrder);
    }

    public async Task<List<PicDto>> GetAll()
    {
        return await _context.Pics
            .OrderBy(p => p.DisplayOrder)
            .Select(p => new PicDto(p.Id, p.Filename, p.DisplayOrder))
            .ToListAsync();
    }

    public Task<List<Pic>> GetAllSync()
    {
        return _context.Pics.ToListAsync();
    }

    public async Task<PicDto> Update(PicDto dto)
    {
        var entity = await _context.Pics.FindAsync(dto.Id);
        if (entity == null)
            throw new ArgumentException($"Trying to update pic: entity with ID {dto.Id} not found.");

        entity.DisplayOrder = dto.DisplayOrder;    

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return dto;
    }
    
}