using Microsoft.AspNetCore.Mvc;
using AutoMapper;


[ApiController]
[Route("api/[controller]/[action]")]
public class VideoController : ControllerBase
{
    readonly private IVideoRepository _videoRepository;
    readonly private IMapper _mapper;
    private readonly VideoService _videoService;
    private readonly ILogger<VideoController> _logger;

    public VideoController(IVideoRepository videoRepository, IMapper mapper, ILogger<VideoController> logger)
    {
        _videoRepository = videoRepository ??
            throw new ArgumentNullException(nameof(videoRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        _logger = logger ??                 
                throw new ArgumentNullException(nameof(mapper));

        _videoService = new VideoService(videoRepository, _mapper, _logger);        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoDto>>> GetVideos()
    {
        return Ok(await _videoService.GetVideos());
    }    


    [HttpPost]
    public async Task<IActionResult> ReOrder(int[] ids)
    {
        return Ok(await _videoService.ReOrder(ids));
    }    

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var video = await _videoRepository.Get(id);

        if (video == null)
        {
            return NotFound();
        }

        await _videoRepository.Delete(video);
        await _videoRepository.SaveChangesAsync();

        return NoContent();
    }    

    [HttpPost]
    public async Task<ActionResult<VideoDto>> Add([FromBody]VideoDto dto)
    {   
        var resultDto = await _videoService.AddVideo(dto);

        if (_videoService.Success == false)
        {
            return BadRequest(new { Message = _videoService.BadRequestMessage });
        }
        
        return Ok(resultDto);
    }  

}
