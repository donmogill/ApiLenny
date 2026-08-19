using WebApplication17.Dtos;

namespace ConfArch.Data.Repositories
{
    
    public class UserRepository : IUserRepository
    {
        private List<UserEntity> users = new()
        {
            // AlfieAndHunter! is the password for the user below, hashed with SHA256
            new UserEntity(3522, "BentEnt", "oeHsJMHi9cmGeeV3Y+ED/w1uepLiuGULSAtsoH/eneI=", "blue", "Admin")
        };

        public UserEntity? GetByUsernameAndPassword(string username, string password)
        {
            var hash = password.Sha256();
            var user = users.SingleOrDefault(u => u.Name.ToLower() == username.ToLower() && u.Password == hash);
            return user;
        }
    }
}
