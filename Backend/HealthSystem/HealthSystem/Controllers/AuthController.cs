using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HealthSystem.Data;
using HealthSystem.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //inject AppDbContext and IConfiguration
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        //Constructer to initilize dependecy
        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Sign In Endpoint
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signInRequest)
        {
            //search for the user by email
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == signInRequest.Email);
            //check if user doesn't exist or wrong password
            if (user == null || !BCrypt.Net.BCrypt.Verify(signInRequest.Password, user.Password))
            {
                return Unauthorized("Invalid Email or password.");
            }
            //Generate the token
            var token = GenerateJwtToken(user);
 
            return Ok(new { Token = token, Role = user.Role.ToString(), ID=user.UserID });
        }
        
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                //Define the claims
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}







