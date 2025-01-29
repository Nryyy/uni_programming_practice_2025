using HromadaWEB.BL.Interfaces;
using HromadaWEB.Models.Entities;
using HromadaWEB.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.RegisterAsync(request);

            if (user is null)
            {
                return BadRequest("User already exists");
            }

            return Ok(user);
        }

        [HttpPost("login")] // Важливо!
        public async Task<ActionResult<string>> Login([FromBody] UserDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { Message = "Username and password are required" });
            }

            var token = await _authService.LoginAsync(request);

            if (token is null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            return Ok(new { Token = token });
        }
    }
}
