public class UserEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string FavoriteColor { get; set; }
    public required string Role { get; set; }
}