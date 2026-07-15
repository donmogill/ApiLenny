using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<bool> SaveChangesAsync();
    Task<bool> ForEditSaveChangesAsync(Show show);
    Task<IEnumerable<Show>> GetAll();
    Task AddShow(Show show);
    Task<Show> Get(int id);
    Task Delete(Show show);

    Task<IEnumerable<Venue>> GetVenues();
    Task<Venue> GetVenue(int id);
    Task AddVenue(Venue venue);
    Task DeleteVenue(Venue venue);
    
    Task<IEnumerable<Band>> GetBands();
    Task<Band> GetBand(int id);
    Task AddBand(Band band);
    Task DeleteBand(Band band);
}    
