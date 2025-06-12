using Microsoft.EntityFrameworkCore;
using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;

namespace MissionBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        //public async Task<UserDto> CreateAsync(UserDto user)
        //{
        //    var newuser = new User
        //    {
        //        Firstname=user.Firstname,
        //        Lastname=user.Lastname,
        //        Email = user.Email,
        //        Contact = user.Contact,
        //    };
        //    _context.Users.Add(newuser);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var userexists= await _context.Users.FindAsync(id);
            if (userexists == null)
            {
                return null;
            }
            var newuser = new UserDto
            {
                Id=userexists.Id,
               Email=userexists.Email,
               Firstname=userexists.Firstname,
               Lastname=userexists.Lastname,
               Contact = userexists.Contact,
               ProfileImage=userexists.ProfileImage,
            };
            return newuser;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var userexists = await _context.Users.Select(m => new UserDto
            {
                Id=m.Id,
                Firstname = m.Firstname,
                Lastname = m.Lastname,
                Email = m.Email,
                Contact = m.Contact,
            }).ToListAsync();
            return userexists;

        }

        public async Task<bool> UpdateAsync(int id,UserDto user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
                return false;

            // Step 2: Update only the fields you want to allow editing
            existingUser.Firstname = user.Firstname;
            existingUser.Lastname = user.Lastname;
            existingUser.Email = user.Email;
            existingUser.Contact = user.Contact;
            existingUser.ProfileImage = user.ProfileImage;
            existingUser.UpdatedAt = DateTime.UtcNow;

            // Step 3: Save changes
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
