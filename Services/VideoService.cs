using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class VideoService
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<VideoController> _logger;
    public bool Success { get; set;}
    public string BadRequestMessage { get; set; }
    private  VideoDto emptyVideoDto {get; set; }


    public VideoService(IVideoRepository videoRepository, IMapper mapper, ILogger<VideoController> logger)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
        Success = true;
        BadRequestMessage = "";
        _logger = logger;
        emptyVideoDto = new VideoDto(0,"", "", DateOnly.MinValue, 0, null, "", 0);
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

    public async Task<VideoDto> AddVideo(VideoDto dto)
    {
        var videoEntity = _mapper.Map<Video>(dto);            

        // fixup dropbox link
        videoEntity.VideoUrl = videoEntity.VideoUrl.Replace("&dl=0", "&raw=1");

        await _videoRepository.Add(videoEntity);

        try
        {
            await _videoRepository.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.InnerException;
            _logger.LogError($"Database add failed: {sqlException?.Message}");
            Success = false;
            BadRequestMessage = "The provided data violates a database constraint.";
            return emptyVideoDto;
        }       
        Success = true;

        return _mapper.Map<VideoDto>(videoEntity);        
    }    
}