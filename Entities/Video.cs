public class Video
{
    public int Id { get; set; }
    public required string Name {get; set;}
    public required string VideoUrl { get; set; }
    public  DateOnly DateUploaded { get; set; }
    public int BandId {get; set;}
    public Band? Band {get; set; }
    public string? Caption {get; set; }
    public int DisplayOrder { get; set; }

}