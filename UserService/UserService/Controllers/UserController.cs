using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Helpers;
using UserService.Model;
using UserService.DTOS;
using UserService.Service;
using RegisterRequest = UserService.DTOS.RegisterRequest;
using LoginRequest = UserService.DTOS.LoginRequest;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserController(UserDbContext userDbContext, JwtTokenGenerator jwtTokenGenerator)
        {
            _userDbContext = userDbContext;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var existingUser = await _userDbContext.users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if(existingUser != null)
            {
                return BadRequest("A user with this email already exists.");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _userDbContext.users.Add(user);
            await _userDbContext.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                FirstName = user.FirstName,
                Email = user.Email
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userDbContext.users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                FirstName = user.FirstName,
                Email = user.Email
            });
        }
    }
}
