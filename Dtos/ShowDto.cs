using System.ComponentModel.DataAnnotations;

public record ShowDto
(
    int Id,
    int BandId,
    int VenueId,
    VenueDto? Venue,
    DateOnly Date,
    TimeOnly Time,
    int Cover  
);
    
