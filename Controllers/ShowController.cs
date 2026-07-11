using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    readonly private IShowRepository _showRepository;
    public ShowController(IShowRepository showRepository)
    {
        _showRepository = showRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowDto>>> Get()
    {
        return Ok(await _showRepository.GetAll());
    }
    
}
