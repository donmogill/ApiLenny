using Api.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

public class BandEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ShowEntity>? Shows { get; set; }
}