using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WSArtemisaApi.Helpers;
using WSArtemisaApi.Models;
using WSArtemisaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WSArtemisaApi.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthService(ApplicationDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> RegisterAsync(User user, string password)
        {
            // Verificar si el usuario ya existe
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == user.Email);
            if (existingUser != null) throw new Exception("Usuario ya existe.");

            // Guardar usuario en base de datos
            user.Password = BCrypt.Net.BCrypt.HashPassword(password); // Encriptar la contraseña
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateJwtToken(user);
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
            if (user == null) throw new Exception("Usuario no encontrado.");

            // Verificar la contraseña
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception("Contraseña incorrecta.");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
