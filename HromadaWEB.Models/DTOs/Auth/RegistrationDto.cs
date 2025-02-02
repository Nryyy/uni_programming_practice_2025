using HromadaWEB.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class RegistrationDto
{
    [Required(ErrorMessage = "Ім'я користувача обов'язкове.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email обов'язковий.")]
    [EmailAddress(ErrorMessage = "Невірний формат email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обов'язковий.")]
    [StringLength(100, ErrorMessage = "Пароль повинен містити від 6 до 100 символів.", MinimumLength = 6)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Підтвердження паролю обов'язкове.")]
    [Compare("Password", ErrorMessage = "Паролі не співпадають.")]
    public string ConfirmPassword { get; set; }
}
