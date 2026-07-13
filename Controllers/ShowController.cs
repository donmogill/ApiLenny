using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SQLitePCL;

[ApiController]
[Route("api/shows")]
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
    public async Task<ActionResult<IEnumerable<ShowDto>>> Get()
    {
        var showEntities = await _showRepository.GetAll();

        var result = _mapper.Map<IEnumerable<ShowDto>>(showEntities);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShowDto>> Get(int id)
    {
        var showEntities = await _showRepository.Get(id);
        if (showEntities == null)
        {
            return NotFound();
        }

        var result = _mapper.Map<IEnumerable<ShowDto>>(showEntities);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ShowDto>> Add([FromBody]ShowDto dto)
    {   
        if (dto == null)
            return NotFound();
        await _showRepository.AddShow(_mapper.Map<ShowEntity>(dto));
        await _showRepository.SaveChangesAsync();
        
        return Ok(dto);
    }    

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var showEntity = await _showRepository.Get(id);

        if (showEntity == null)
        {
            return NotFound();
        }

        await _showRepository.Delete(showEntity);
        await _showRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> UpdatePointOfInterest([FromBody]ShowDto showDto)
    {
        var showEntity = await _showRepository.Get(showDto.Id);
        if (showEntity == null)
        {
            return NotFound("Show was not found in the database.");
        }

        _mapper.Map(showDto, showEntity);
        await _showRepository.ForEditSaveChangesAsync(showEntity);

        return NoContent();
    } 
           
}
