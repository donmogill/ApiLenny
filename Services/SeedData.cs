using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        
        builder.Entity<Show>().HasData(new List<Show> {
            new Show {
                Id = 1,                                
                VenueId = 1,
                BandId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
                Time = TimeOnly.Parse("9:00 PM")                
            },            
        });     
        builder.Entity<Band>().HasData(new List<Band> {
            new Band {
                Id = 1,                
                Name = "Pyschedelic RoadShow"                
            },            
        });
        
               
    }
}