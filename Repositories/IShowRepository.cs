using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<bool> SaveChangesAsync();
    Task<bool> ForEditSaveChangesAsync(ShowEntity showEntity);
    Task<IEnumerable<ShowEntity>> GetAll();
    Task AddShow(ShowEntity showEntity);
    Task<IEnumerable<VenueEntity>> GetVenues();
    Task<ShowEntity> Get(int id);
    Task Delete(ShowEntity showEntity);
}