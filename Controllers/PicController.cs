using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/pic")]
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
}
