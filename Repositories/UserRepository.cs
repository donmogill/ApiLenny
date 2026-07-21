using WebApplication17.Dtos;

namespace ConfArch.Data.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private List<UserEntity> users = new()
        {
            new UserEntity(3522, "don", "oeHsJMHi9cmGeeV3Y+ED/w1uepLiuGULSAtsoH/eneI=", "blue", "Admin")
        };

        public UserEntity? GetByUsernameAndPassword(string username, string password)
        {
            var hash = password.Sha256();
            var user = users.SingleOrDefault(u => u.Name == username && u.Password == hash);
            return user;
        }
    }
}
