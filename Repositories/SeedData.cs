using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        /*
        builder.Entity<VenueEntity>().HasData(new List<VenueEntity> {
            new VenueEntity {
                Id = 1,                
                Name = "The Hive",
                Address ="2780 Tapo Canyon Rd, Suite B4",
                City = "Simi Valley"
            },            
        });       
        builder.Entity<ShowEntity>().HasData(new List<ShowEntity> {
            new ShowEntity {
                Id = 1,                                
                VenueId = 1,
                BandId = 1,
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