using MissionBackend.Data;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MissionBackend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
