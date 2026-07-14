using System.Data.SqlTypes;

public class ShowEntity
{
    public int Id { get; set; }
    public int BandId { get; set; }    
    public BandEntity Band { get; set; }
    public string BandName { get; set; }
    public int VenueId {get; set; }
    public VenueEntity Venue { get; set; }
    public DateOnly Date {get; set; }
    public TimeOnly Time { get; set; }      
    public int Cover { get; set; }  
}