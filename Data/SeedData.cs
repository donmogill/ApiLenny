using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<PicEntity>().HasData(new List<PicEntity> {
            new PicEntity {
                Id = 1,                
                Filename = "don.JPEG",
                DisplayOrder = 1
            },
            new PicEntity {
                Id = 2,                
                Filename = "dori.JPEG",
                DisplayOrder = 2
            },
            new PicEntity {
                Id = 3,                
                Filename = "three.JPEG",
                DisplayOrder = 3
            },
        });       
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
                BandName = "Pyschedelic RoadShow",
                VenueId = 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(10)),
                Time = TimeOnly.Parse("9:00 PM")
                
            },            
        });       
    }
}