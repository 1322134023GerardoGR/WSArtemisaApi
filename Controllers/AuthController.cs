using Microsoft.AspNetCore.Mvc;
using WSArtemisaApi.Models;
using WSArtemisaApi.Services;

namespace WSArtemisaApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Name = model.Name,
                LastName = model.LastName,
                CardBrandId = model.CardBrandId,
                Wallet = model.Wallet
            };
            var token = await _authService.RegisterAsync(user, model.Password);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthModel model)
        {
            var token = await _authService.LoginAsync(model.Email, model.Password);
            return Ok(new { Token = token });
        }
    }
}
