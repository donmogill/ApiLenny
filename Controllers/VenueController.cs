using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/venues")]
public class VenueController : ControllerBase
{
    readonly private IShowRepository _showRepository;
    readonly private IMapper _mapper;
    public VenueController(IShowRepository showRepository, IMapper mapper)
    {
        _showRepository = showRepository ??
            throw new ArgumentNullException(nameof(showRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VenueDto>>> GetVenues()
    {
        var venueEntities = await _showRepository.GetVenues();

        var result = _mapper.Map<IEnumerable<VenueDto>>(venueEntities);
        return Ok(result);
    }    
}