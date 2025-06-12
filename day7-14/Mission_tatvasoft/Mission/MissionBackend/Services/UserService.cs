using Microsoft.EntityFrameworkCore;
using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;

namespace MissionBackend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repo;

        public UserService(AppDbContext context,IUserRepository repo)
        {
            _context = context;
            _repo = repo;
        }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;

            if (!VerifyPassword(password, user.Password))
                return null;

            return user;
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
        //public async Task<UserDto> CreateAsync(UserDto dto)
        //{
        //    var userexists = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower());
        //    if (userexists != null)
        //    {
        //        throw new Exception("User with this email already exists.");
        //    }
        //    return await _repo.CreateAsync(dto);
        //}

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);

        public async Task<UserDto> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
        public async Task<List<UserDto>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<bool> UpdateAsync(int id, UserDto dto)
        {    
            return await _repo.UpdateAsync(id,dto);
        }
    }
}
