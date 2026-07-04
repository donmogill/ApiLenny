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
    }
}