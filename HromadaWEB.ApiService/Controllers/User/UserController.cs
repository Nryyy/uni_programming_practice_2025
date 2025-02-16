using MediatR;
using Microsoft.AspNetCore.Mvc;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.User;
using HromadaWEB.Service.Queries.User;
using Microsoft.AspNetCore.Authorization;

namespace HromadaWEB.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Отримати користувача за ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Отримати всіх користувачів
        [HttpGet("all_users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            if (users == null || !users.Any())  // Перевірка на порожній список
            {
                return NotFound(); // Якщо користувачі не знайдені, повернути NotFound
            }
            return Ok(users);
        }

        // Оновити користувача
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            if (id != user.Id) return BadRequest("User ID mismatch.");

            try
            {
                await _mediator.Send(new UpdateUserCommand(user));
            }
            catch (Exception ex)
            {
                // Логування помилки
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // Видалити користувача
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand(id));
            }
            catch (Exception ex)
            {
                // Логування помилки
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }
    }
}
