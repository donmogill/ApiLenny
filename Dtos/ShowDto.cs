using System.ComponentModel.DataAnnotations;

public record ShowDto
(
    int Id,
    int BandId,
    BandDto BandDto,
    int VenueId,
    VenueDto Venue,
    DateOnly Date,
    TimeOnly Time
);
    
