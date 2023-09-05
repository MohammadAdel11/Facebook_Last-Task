using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Facebook.Tables;
using FirstApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Facebook.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ApplicationDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<User> AddUser(UserRequestModel m)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(m.Password);

            var user = new User()
            {
                Username = m.FullName,
                Email = m.email,
                Password = passwordHash,
                CreatedAt=DateTime.Now,
            };
            var result = await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            if (existingUser != null)
            {
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }
        public async Task<User?> GetUser(AuthModel m)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email.ToUpper() == m.email.ToUpper());
        }

        public async Task<User> DeleteUser(int id)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim("Name", user.Username),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public string? GetCurrentLoggedIn()
        {
            string result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue("name");
            }
            return result;
        }
    }
}

