using MissionBackend.Interfaces;
using MissionBackend.Models;
using MissionBackend.Dto;
using MissionBackend.Data;
using System.Threading.Tasks;

namespace MissionBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;


        public AuthService(AppDbContext context,IAuthRepository authRepository, IUserRepository userRepository)
        {
            _context = context;
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _authRepository.GetUserByEmailAsync(email);
            if (user == null) return null;

            // Password verification (use secure hash in real apps!)
            if (user.Password != password) return null;

            return user;
        }

        public async Task<RegisterDto> RegisterAsync(RegisterDto user)
        {
            var userexists = await _authRepository.GetUserByEmailAsync(user.Email);
            if (userexists != null) return null;
            var createuser = new User
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Contact = user.Contact,
                UserType = user.UserType
            };
            await _context.Users.AddAsync(createuser);
            await _context.SaveChangesAsync();
            var registerdto=new RegisterDto
            {
                FirstName=createuser.Firstname,
                LastName=createuser.Lastname,
                Email=createuser.Email,
                Password=createuser.Password,
                Contact=createuser.Contact,
                UserType=createuser.UserType
            };
            return registerdto;
        }
    }
}
