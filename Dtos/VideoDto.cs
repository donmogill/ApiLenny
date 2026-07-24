public record VideoDto (
    int Id,
    string Name,
    string YoutubeId,
    DateOnly DateUploaded,
    int BandId,
    Band? Band,
    string? Caption,
    int DisplayOrder 
);

