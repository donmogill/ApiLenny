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
                Name = "Girls Got Rhythm At Mrs Olsons",  
                VideoUrl = "https://www.dropbox.com/scl/fi/on30us31lel4t0gdiki4z/Video-Jul-20-2026-11-43-39-PM.mp4?rlkey=mznodpq2plhkdcuoqdkxwr0rq&st=xs9zskw3&raw=1",
                BandId = 2,            
                DateUploaded = DateOnly.Parse("07/19/2026"),
                Caption = "Girls Got Rhythm At Mrs Olsons!",
            },            
            new Video {
                Id = 2,                
                Name = "One Way to rock",  
                VideoUrl = "https://www.dropbox.com/scl/fi/zq9ieuxymrsj5hah8n6x7/Video-Jul-19-2026-2-23-11-PM.mp4?rlkey=k2ecapfc1txigldxvis9qs1yz&st=of67g5ba&raw=1",
                BandId = 1,            
                DateUploaded = DateOnly.Parse("07/19/2026"),
                Caption = "There's Only One Way to Rock!",
            },            
        });
        
               
    }
}