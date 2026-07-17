using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]/[action]")]
public class ShowController : ControllerBase
{
    readonly private IShowRepository _showRepository;
    readonly private IMapper _mapper;
    private readonly ILogger<PicController> _logger;
    private readonly ShowService _showService;

    public ShowController(IShowRepository showRepository, IMapper mapper, ILogger<PicController> logger)
    {
        _showRepository = showRepository ??
            throw new ArgumentNullException(nameof(showRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        _logger = logger ??                 
                throw new ArgumentNullException(nameof(mapper));

        _showService = new ShowService(showRepository, _mapper, _logger);

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowDto>>> GetShows()
    {
        var showEntities = await _showRepository.GetAll();

        var result = _mapper.Map<IEnumerable<ShowDto>>(showEntities);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetOneShow")]
    public async Task<ActionResult<ShowDto>> GetOneShow(int id)
    {
        var showEntities = await _showRepository.Get(id);
        if (showEntities == null)
        {
            return NotFound();
        }

        var result = _mapper.Map<ShowDto>(showEntities);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ShowDto>> Add([FromBody]ShowDto dto)
    {   
        if (dto == null)
        {
            _logger.LogWarning("Missing show to add.");
            return NotFound();
        }            

        var resultDto = await _showService.AddShowComplete(dto);

        if (_showService.Success == false)
        {
            return BadRequest(new { Message = _showService.BadRequestMessage });
        }
        
        return CreatedAtRoute("GetOneShow",
                 new
                 {
                     id = resultDto.Id
                 },
                 resultDto);
    }    

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var show = await _showRepository.Get(id);

        if (show == null)
        {
            return NotFound();
        }

        await _showRepository.Delete(show);
        await _showRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody]ShowDto showDto)
    {
        var show = await _showRepository.Get(showDto.Id);
        if (show == null)
        {
            return NotFound("Show was not found in the database.");
        }

        _mapper.Map(showDto, show);
        await _showRepository.ForEditSaveChangesAsync(show);

        return NoContent();
    } 
           
}
