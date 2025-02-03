using HromadaWEB.Service.Queries.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.Role
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<Models.Entities.Role>>> GetAllRoles()
        {
            var roles = await _mediator.Send(new GetRolesQuery());
            if (roles == null || !roles.Any())
            {
                return NotFound();
            }
            return Ok(roles);
        }
    }
}
