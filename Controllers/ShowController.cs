using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SQLitePCL;

[ApiController]
[Route("api/[controller]/[action]")]
public class ShowController : ControllerBase
{
    readonly private IShowRepository _showRepository;
    readonly private IMapper _mapper;
    public ShowController(IShowRepository showRepository, IMapper mapper)
    {
        _showRepository = showRepository ??
            throw new ArgumentNullException(nameof(showRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShowDto>>> GetShows()
    {
        var showEntities = await _showRepository.GetAll();

        var result = _mapper.Map<IEnumerable<ShowDto>>(showEntities);
        return Ok(result);
    }

    [HttpGet("{id}")]
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
            return NotFound();
        await _showRepository.AddShow(_mapper.Map<Show>(dto));
        await _showRepository.SaveChangesAsync();
        
        return Ok(dto);
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
    public async Task<ActionResult> UpdatePointOfInterest([FromBody]ShowDto showDto)
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
