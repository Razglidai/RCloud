using Microsoft.EntityFrameworkCore;
using RCloud.Models;

namespace RCloud.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindByUsernameAsync(string username)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task AddUserAsync(User user)
        {

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}