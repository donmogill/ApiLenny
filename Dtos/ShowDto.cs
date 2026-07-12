using System.ComponentModel.DataAnnotations;

public record ShowDto
(
    int Id,
    string BandName,
    int VenueId,
    VenueDto? Venue,
    DateOnly Date,
    TimeOnly Time
);
    
