using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<ShowEntity>> GetAll();
    Task AddShow(ShowEntity showEntity);
}