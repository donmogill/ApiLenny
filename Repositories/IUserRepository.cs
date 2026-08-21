
namespace ConfArch.Data.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto?> GetByUsernameAndPassword(string username, string password);
    }
}
