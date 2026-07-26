using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class VideoService
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<VideoController> _logger;
    public bool Success { get; set;}
    public string BadRequestMessage { get; set; }


    public VideoService(IVideoRepository videoRepository, IMapper mapper, ILogger<VideoController> logger)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
        Success = true;
        BadRequestMessage = "";
        _logger = logger;
    }

    public async Task<IEnumerable<VideoDto>> GetVideos()
    {
        var videoEntities = await _videoRepository.GetAll();
        return _mapper.Map<IEnumerable<VideoDto>>(videoEntities);
    }
    public async Task<int[]> ReOrder(int[] ids)
    {
        int newOrder = 1;
        foreach (int id in ids)
        {
            // get video from database
            var video = await _videoRepository.Get(id);

            if (video == null)
            {
                _logger.LogWarning($"Update: No video with id:{id}");
                Success = false;
                BadRequestMessage = "Warning: No video found for update.";
                return ids;
                
            }
            video.DisplayOrder = newOrder;
            
            try
            {
                await _videoRepository.Update(video);                
            }
            catch (DbUpdateException ex)
            {
                var sqlException = ex.InnerException;
                _logger.LogError($"Database ReOrder failed: {sqlException?.Message}");
                Success = false;
                BadRequestMessage = "The provided data violates a database constraint.";
                return ids;                
            }
            newOrder++;
        }
        
        return ids;

    }        
}