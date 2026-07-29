public record VideoDto (
    int Id,
    string Name,
    string VideoUrl,
    DateOnly DateUploaded,
    int BandId,
    Band? Band,
    string? Caption,
    int DisplayOrder 
);

