using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        /*
        builder.Entity<ShowEntity>().HasData(new List<ShowEntity> {
            new ShowEntity {
                Id = 1,                                
                VenueId = 1,
                BandEntityId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
                Time = TimeOnly.Parse("9:00 PM")
                
            },            
        });     
        builder.Entity<BandEntity>().HasData(new List<BandEntity> {
            new BandEntity {
                Id = 1,                
                Name = "Pyschedelic RoadShow"                
            },            
        });
        */
               
    }
}