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

    public ShowDto AddShowComplete(ShowDto dto)
    {
        var showEntity = _mapper.Map<Show>(dto);            
        _showRepository.AddShow(showEntity);

        try
        {
            _showRepository.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.InnerException;
            _logger.LogError($"Database add failed: {sqlException?.Message}");
            Success = false;
            BadRequestMessage = "The provided data violates a database constraint.";
        }       
        Success = true;

        return _mapper.Map<ShowDto>(showEntity);        
    }

    public Show AddShow(ShowDto dto)
    {
        var showEntity = _mapper.Map<Show>(dto);            
        _showRepository.AddShow(showEntity);

        return showEntity;        
    }

    public bool AddShowSave()
    {
        try
        {
            _showRepository.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.InnerException;
            _logger.LogError($"Database add failed: {sqlException?.Message}");
            return false;
        }       

        return true;        
    }

    public ShowDto ReturnDto(Show showEntity)
    {
        return _mapper.Map<ShowDto>(showEntity);
    }

    
}