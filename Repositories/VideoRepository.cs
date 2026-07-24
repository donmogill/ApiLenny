using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

public class VideoRepository : IVideoRepository
{
    private readonly LennyDbContext _context;

    public VideoRepository(LennyDbContext context)
    {
        _context = context;
    }
    public async Task<List<Video>> GetAll()
    {
        return await _context.Videos
            .OrderBy(v => v.DisplayOrder)            
            .Include(v=>v.Band)
            .ToListAsync();
    }

    public async Task<Video> Get(int id)
    {
        var entity = await _context.Videos.SingleOrDefaultAsync(p => p.Id == id);
        if (entity == null)
        {
            throw new ArgumentException($"Trying to get video: entity with ID {id} not found.");
        }
        return entity;
    }

    public async Task<Video> Update(Video dto)
    {
        var entity = await _context.Videos.FindAsync(dto.Id);
        if (entity == null)
            throw new ArgumentException($"Trying to update video: entity with ID {dto.Id} not found.");

        entity.DisplayOrder = dto.DisplayOrder;    

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }    

    public async Task Delete(Video video)
    {
        _context.Remove(video);
    }

    public async Task Add(Video video)
    {
        _context.Videos.Add(video);              
    }    

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }    
}

public interface IVideoRepository
{
    Task<List<Video>> GetAll();
    Task<Video> Get(int id);
    Task<Video> Update(Video dto);
    Task Delete(Video video);
    Task Add(Video video);
    Task SaveChangesAsync();
}