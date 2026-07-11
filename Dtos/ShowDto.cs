using System.ComponentModel.DataAnnotations;

public record ShowDto
(
    int Id,
    [property: Required] string BandName,
    [property: Required] int VenueId,
    VenueEntity Venue,
    [property: Required] DateOnly Date,
    [property: Required] TimeOnly Time
);
    
