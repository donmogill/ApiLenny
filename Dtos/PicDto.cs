using System.ComponentModel.DataAnnotations;

public record PicDto(
    int Id, 
    [property: Required] string Filename, 
    [property: Required] int DisplayOrder);