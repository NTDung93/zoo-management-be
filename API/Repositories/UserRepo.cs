using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ElectricStoreDbContext _context;

        public UserRepo(ElectricStoreDbContext context)
        {
            this._context = context;
        }

        public async Task<User> GetUser(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId.ToLower().Equals(id.ToLower()));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.OrderBy(u => u.UserName).ToListAsync();
        }
    }
}
