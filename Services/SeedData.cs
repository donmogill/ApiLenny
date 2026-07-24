using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        
        // builder.Entity<Show>().HasData(new List<Show> {
        //     new Show {
        //         Id = 1,                                
        //         VenueId = 1,
        //         BandId = 1,
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
        //         Time = TimeOnly.Parse("9:00 PM")                
        //     },            
        // });     
        // builder.Entity<Band>().HasData(new List<Band> {
        //     new Band {
        //         Id = 1,                
        //         Name = "Pyschedelic RoadShow"                
        //     },            
        // });
         builder.Entity<Video>().HasData(new List<Video> {
            new Video {
                Id = 1,                
                Name = "Don plays Black Beauty",  
                YoutubeId = "o-Vw1tbGLtw",
                BandId = 2,            
                DateUploaded = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                Caption = "Don plays some jazzy acoustic!",
            },            
            new Video {
                Id = 2,                
                Name = "Psychedelic RoadShow sizzle",  
                YoutubeId = "VWN9nuJODs0",
                BandId = 1,            
                DateUploaded = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
                Caption = "Look at our cool band!",
            },            
        });
        
               
    }
}