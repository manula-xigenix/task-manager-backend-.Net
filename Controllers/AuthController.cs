using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementApp_Test.Data;
using TaskManagementApp_Test.Models;

namespace TaskManagementApp_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _db;

        public AuthController(IConfiguration config, AppDbContext db)
        {
            _config = config;
            _db = db;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginModel model)
        {
            if (_db.Users.Any(u => u.Username == model.Username))
                return BadRequest("Username already exists.");

            var user = new User { Username = model.Username, Password = model.Password }; // ⚠️ should hash
            _db.Users.Add(user);
            _db.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _db.Users.FirstOrDefault(u =>
                        u.Username == model.Username && u.Password == model.Password);

            if (user == null)
                return Unauthorized();

            var token = GenerateJwtToken(user.Username);
            return Ok(new { token });
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}