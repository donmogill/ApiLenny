using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]/[action]")]
public class PicController : ControllerBase
{
    readonly private IPicRepository _picRepository;
    private readonly ILogger<PicController> _logger;
        
    public PicController(IPicRepository picRepository, ILogger<PicController> logger)
    {
        _picRepository = picRepository;
        _logger = logger;
        
    }
    [HttpPost]
    public async Task<IActionResult> Add(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            _logger.LogWarning("No file Picked in PicController Add");
            return BadRequest("No file Picked.");
        }
            

        var service = new UploadService(file);    

        service.CopyFileToServer();

        await _picRepository.Add(new PicDto(0, file.FileName, 0));

        return Ok(new { filePath = service.UploadPath });
    }

    [HttpPost]
    public async Task<IActionResult> ReOrder(int[] ids)
    {
        int newOrder = 1;
        foreach (int id in ids)
        {
            // get pic from database
            var pic = await _picRepository.Get(id);

            var newPicDto = new PicDto(pic.Id, pic.Filename, newOrder);          
            newOrder++;
            
            await _picRepository.Update(newPicDto);
        }
        
        return Ok(ids);

    }    
}
