using Microsoft.AspNetCore.Mvc;
public interface IShowRepository
{
    Task<bool> SaveChangesAsync();
    Task<bool> ForEditSaveChangesAsync(ShowEntity showEntity);
    Task<IEnumerable<ShowEntity>> GetAll();
    Task AddShow(ShowEntity showEntity);
    Task<ShowEntity> Get(int id);
    Task Delete(ShowEntity showEntity);

    Task<IEnumerable<VenueEntity>> GetVenues();
    Task<VenueEntity> GetVenue(int id);
    Task AddVenue(VenueEntity venueEntity);
    Task DeleteVenue(VenueEntity venueEntity);
    
    Task<IEnumerable<BandEntity>> GetBands();
    Task<BandEntity> GetBand(int id);
    Task AddBand(BandEntity bandEntity);
    Task DeleteBand(BandEntity bandEntity);
}    
