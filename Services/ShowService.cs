using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShowService
{
    private readonly IMapper _mapper;
    private readonly ILogger<PicController> _logger;
    private IShowRepository _showRepository { get; }

    public ShowService(IShowRepository showRepository, IMapper mapper, ILogger<PicController> logger)
    {
        _showRepository = showRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public Show AddShow(ShowDto dto)
    {
        var showEntity = _mapper.Map<Show>(dto);            
        _showRepository.AddShow(showEntity);

        return showEntity;        
    }

    public bool SaveAdd()
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

    
}