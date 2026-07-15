using Microsoft.AspNetCore.Mvc;

public interface IPicRepository
{
    Task<List<PicDto>> GetAll();
    Task<PicDto> Get(int id);
    //Task<PicDto> Add(PicDto pic);
    Task<PicDto> Update(PicDto pic);
    Task<PicDto> Delete(int id);
    Task<List<Pic>> GetAllSync();
    Task<PicDto> Add(PicDto pic);
}
