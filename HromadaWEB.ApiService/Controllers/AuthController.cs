using HromadaWEB.BL.Interfaces;
using HromadaWEB.Models.DTOs;
using HromadaWEB.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HromadaWEB.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegistrationDto request)
        {
            try
            {
                var user = await _authService.RegisterAsync(request);

                return Ok(user);
            }
            catch (InvalidOperationException ex) // Обробляємо винятки
            {
                return BadRequest(ex.Message); // Відправляємо повідомлення про помилку
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { Message = "Email and password are required" });
            }

            var token = await _authService.LoginAsync(request);

            if (token is null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            return Ok(new { Token = token });
        }

    }
}
