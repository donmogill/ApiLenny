public interface IPicRepository
{
    Task<List<PicDto>> GetAll();
    Task<List<PicDto>> Get(int id);
    Task<List<PicDto>> Add(PicDto pic);
    Task<List<PicDto>> Update(PicDto pic);
    Task<List<PicDto>> Delete(int id);
}
