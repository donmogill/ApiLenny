using Microsoft.AspNetCore.Mvc;
using AutoMapper;


[ApiController]
[Route("api/[controller]/[action]")]
public class VideoController : ControllerBase
{
    readonly private IVideoRepository _videoRepository;
    readonly private IMapper _mapper;
    private readonly VideoService _videoService;

    public VideoController(IVideoRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository ??
            throw new ArgumentNullException(nameof(videoRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        _videoService = new VideoService(videoRepository, _mapper);        
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoDto>>> GetVideos()
    {
        return Ok(await _videoService.GetVideos());
    }    

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<VideoDto>>> GetVideos()
    // {
    //     var videoEntities = await _videoRepository.GetAll();

    //     var result = _mapper.Map<IEnumerable<VideoDto>>(videoEntities);
    //     return Ok(result);
    // }  

    [HttpPost]
    public async Task<IActionResult> ReOrder(int[] ids)
    {
        int newOrder = 1;
        foreach (int id in ids)
        {
            // get video from database
            var video = await _videoRepository.Get(id);
            video.DisplayOrder = newOrder;
            
            await _videoRepository.Update(video);
            newOrder++;
        }
        
        return Ok(ids);

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
        if (dto == null)
        {
           return  BadRequest("No VideoDto was provided.");
        }

        await _videoRepository.Add(_mapper.Map<Video>(dto));
        await _videoRepository.SaveChangesAsync();
        
        return Ok(dto);
    }  

}
