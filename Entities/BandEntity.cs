using Microsoft.EntityFrameworkCore.Metadata;

public class BandEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ShowEntity> Shows { get; set; }
            = new List<ShowEntity>();    
    public BandEntity(string name)
    {
        Name = name;
    }
}