using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShowService
{
    private readonly IMapper _mapper;
    private readonly ILogger<PicController> _logger;
    private IShowRepository _showRepository { get; }  
    

    public bool Success { get; set;}
    public string BadRequestMessage { get; set; }

    public ShowService(IShowRepository showRepository, IMapper mapper, ILogger<PicController> logger)
    {
        _showRepository = showRepository;
        _mapper = mapper;
        _logger = logger;
        Success = true;
        BadRequestMessage = "";
        
    }

    public async Task<ShowDto> AddShowComplete(ShowDto dto)
    {
        var showEntity = _mapper.Map<Show>(dto);            
        await _showRepository.AddShow(showEntity);

        try
        {
            await _showRepository.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.InnerException;
            _logger.LogError($"Database add failed: {sqlException?.Message}");
            Success = false;
            BadRequestMessage = "The provided data violates a database constraint.";
            return new ShowDto(0, 0, 0, null, DateOnly.MinValue, TimeOnly.MinValue, 0);
        }       
        Success = true;

        return _mapper.Map<ShowDto>(showEntity);        
    }
    public async Task<IEnumerable<ShowDto>> GetShows()
    {
        var showEntities = await _showRepository.GetAll();

        return _mapper.Map<IEnumerable<ShowDto>>(showEntities);
    }


    
}