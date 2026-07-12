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

    [HttpPost]
    public async Task<ActionResult<ShowDto>> Add([FromBody]ShowDto dto)
    {   
        if (dto == null)
            return NotFound();
        await _showRepository.AddShow(_mapper.Map<ShowEntity>(dto));
        await _showRepository.SaveChangesAsync();
        
        return Ok(dto);
    }    
}
