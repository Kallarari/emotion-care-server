using EmotionCareServer.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmotionCareServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] ILoginRequest request)
        {
            // Verifica se o nome e a senha estão corretos no paciente
            var patient = _context.Patients
                .FirstOrDefault(p => p.Name == request.Name && p.Password == request.Password);

            // Verifica se o nome e a senha estão corretos no psicólogo
            var psychologist = _context.Psychologists
                .FirstOrDefault(p => p.Name == request.Name && p.Password == request.Password);

            if (patient == null && psychologist == null)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Name)
            };

            // Adiciona a claim para identificar o tipo de usuário
            if (patient != null)
            {
                claims.Add(new Claim("Role", "Patient"));
                claims.Add(new Claim("PatientId", patient.Id.ToString()));
            }
            else if (psychologist != null)
            {
                claims.Add(new Claim("Role", "Psychologist"));
                claims.Add(new Claim("PsychologistId", psychologist.Id.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
