using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    readonly private IPicRepository _picRepository;
    public UploadController(IPicRepository picRepository)
    {
        _picRepository = picRepository;
    }
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var service = new UploadService(file);    

        service.CopyFileToServer(service.CreateUploadsDirectory());

        await _picRepository.Add(new PicDto(0, file.FileName, 0));

        return Ok(new { filePath = service.UploadPath });

    }
}
