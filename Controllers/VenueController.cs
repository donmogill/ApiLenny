using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

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

    [HttpPost]
    public async Task<ActionResult<VenueDto>> Add([FromBody]VenueDto dto)
    {   
        if (dto == null)
        {
q           return Results.Problem(
                "Venue Dto is null", 
                statusCode: StatusCodes.Status404NotFound);

        }
    
        await _showRepository.AddVenue(_mapper.Map<Venue>(dto));
        await _showRepository.SaveChangesAsync();
        
        return Ok(dto);
    }  
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var venue = await _showRepository.GetVenue(id);

        if (venue == null)
        {
            return NotFound();
        }

        await _showRepository.DeleteVenue(venue);
        await _showRepository.SaveChangesAsync();

        return NoContent();
    }    
}