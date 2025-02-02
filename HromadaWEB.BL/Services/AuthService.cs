using HromadaWEB.DB;
using HromadaWEB.BL.Interfaces;
using HromadaWEB.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using HromadaWEB.Models.DTOs;
using System.Threading.Tasks;

namespace HromadaWEB.BL.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Login

        public async Task<string?> LoginAsync(LoginDto request)
        {
            var user = await _context.Users
                    .Include(u => u.Role) // Завантажуємо роль користувача
                    .FirstOrDefaultAsync(u => u.Email == request.Email); // Перевірка за email

            if (user is null)
            {
                return "User not found"; // Користувач не знайдений
            }

            var passwordVerificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return "Invalid password"; // Невірний пароль
            }

            return CreateToken(user); // Якщо успішно, повертаємо JWT токен
        }

        #endregion

        #region Register

        public async Task<string?> RegisterAsync(RegistrationDto request)
        {
            string validationMessage;
            if (!ValidateRegistrationDto(request, out validationMessage))
            {
                return validationMessage; // Повідомлення про помилку валідації
            }

            // Перевірка наявності користувача за username та email
            if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return "Username is already taken."; // Username вже зайнятий
            }

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                return "Email is already in use."; // Email вже використовується
            }

            var user = await CreateUser(request); // Викликаємо асинхронний метод
            if (user == null) return "Role 'Admin' not found."; // Якщо роль не знайдена

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync(); // Збереження користувача в базі
            }
            catch (Exception ex)
            {
                return "Error saving user to the database: " + ex.Message; // Обробка помилок збереження
            }

            return "Registration successful. Please check your email for confirmation."; // Успішна реєстрація
        }

        #endregion

        #region Private Helper Methods

        // Створення JWT токена
        private string CreateToken(User user)
        {
            if (user.Role == null)
            {
                throw new InvalidOperationException("User role is not assigned.");
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)  // Тепер перевірено, що user.Role не null
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        }

        // Метод для створення користувача
        private async Task<User?> CreateUser(RegistrationDto request)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin"); // Виправлення назви ролі
            if (userRole == null)
            {
                return null; // Якщо роль не знайдена, повертаємо null
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = new PasswordHasher<User>().HashPassword(new User(), request.Password),
                RoleId = userRole.Id, // Призначення ролі
                Role = userRole // Присвоєння ролі
            };

            return user;
        }

        // Валідація даних для входу
        private bool ValidateLoginDto(LoginDto request, out string validationMessage)
        {
            validationMessage = string.Empty;
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                validationMessage = "Email and Password are required.";
                return false;
            }

            return true;
        }

        // Валідація даних для реєстрації
        private bool ValidateRegistrationDto(RegistrationDto request, out string validationMessage)
        {
            validationMessage = string.Empty;

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Password) || string.IsNullOrEmpty(request.ConfirmPassword))
            {
                validationMessage = "All fields are required.";
                return false;
            }

            if (request.Password != request.ConfirmPassword)
            {
                validationMessage = "Passwords do not match.";
                return false;
            }

            if (request.Password.Length < 6)
            {
                validationMessage = "Password must be at least 6 characters long.";
                return false;
            }

            return true;
        }

        #endregion
    }
}
