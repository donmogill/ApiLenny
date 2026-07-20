using WebApplication17.Dtos;

namespace ConfArch.Data.Repositories
{
    public interface IUserRepository
    {
        UserEntity? GetByUsernameAndPassword(string username, string password);
    }
}
