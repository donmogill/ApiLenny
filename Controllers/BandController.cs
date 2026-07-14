using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/Bands")]
public class BandController : ControllerBase
{
    readonly private IShowRepository _showRepository;
    readonly private IMapper _mapper;
    public BandController(IShowRepository showRepository, IMapper mapper)
    {
        _showRepository = showRepository ??
            throw new ArgumentNullException(nameof(showRepository));

        _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BandDto>>> GetBands()
    {
        var BandEntities = await _showRepository.GetBands();

        var result = _mapper.Map<IEnumerable<BandDto>>(BandEntities);
        return Ok(result);
    }    

    [HttpPost]
    public async Task<ActionResult<BandDto>> Add([FromBody]BandDto dto)
    {   
        if (dto == null)
            return NotFound();
            
        await _showRepository.AddBand(_mapper.Map<BandEntity>(dto));
        await _showRepository.SaveChangesAsync();
        
        return Ok(dto);
    }  
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var BandEntity = await _showRepository.GetBand(id);

        if (BandEntity == null)
        {
            return NotFound();
        }

        await _showRepository.DeleteBand(BandEntity);
        await _showRepository.SaveChangesAsync();

        return NoContent();
    }    
}