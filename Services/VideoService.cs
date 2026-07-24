using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class VideoService
{
    private readonly IVideoRepository _videoRepository;
    private readonly IMapper _mapper;

    public VideoService(IVideoRepository videoRepository, IMapper mapper)
    {
        _videoRepository = videoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VideoDto>> GetVideos()
    {
        var videoEntities = await _videoRepository.GetAll();
        return _mapper.Map<IEnumerable<VideoDto>>(videoEntities);
    }
}