using Microsoft.EntityFrameworkCore.Metadata;

public class Band
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Show> Shows { get; set; }
            = new List<Show>();    
    
}