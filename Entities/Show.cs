using System.Data.SqlTypes;

public class Show
{
    public int Id { get; set; }
    public int BandId { get; set; }  
    public int VenueId {get; set; }
    public Venue? Venue { get; set; }
    public DateOnly Date {get; set; }
    public TimeOnly Time { get; set; }      
    public int Cover { get; set; }  
}