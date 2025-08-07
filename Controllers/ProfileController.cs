using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WSArtemisaApi.Services;
using WSArtemisaApi.DTOs;

namespace WSArtemisaApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr == null)
                return Unauthorized("Usuario no autenticado.");

            var user = await _profileService.GetProfileAsync(Guid.Parse(userIdStr));
            if (user == null)
                return NotFound("Usuario no encontrado.");

            return Ok(new
            {
                user.Email,
                user.Name,
                user.LastName,
                user.PhotoPath,
                user.CardBrandId,
                user.Wallet,
                user.CreatedAt,
                user.UpdatedAt
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateDTO model)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdStr == null)
                return Unauthorized("Usuario no autenticado.");

            await _profileService.UpdateProfileAsync(
                Guid.Parse(userIdStr),
                model.Name,
                model.LastName,
                model.CardBrandId,
                model.Wallet,
                model.PhotoPath
            );

            return Ok(new { message = "Perfil actualizado correctamente." });
        }
    }
}
