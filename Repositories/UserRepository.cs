using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data.Repositories
{
    
    public class UserRepository : IUserRepository
    {

        LennyDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(LennyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<UserDto?> GetByUsernameAndPassword(string username, string password)
        {
            var hash = password.Sha256();

            var user = _context.Users
                .Where(u => u.Name.ToLower() == username.ToLower() && u.Password == hash)
                .SingleOrDefault();

            var userDto = _mapper.Map<UserDto>(user);

            return await Task.FromResult(userDto);
        }
    }
}
