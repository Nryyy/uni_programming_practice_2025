using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.Templates;
using HromadaWEB.Service.Queries.Templates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.Templates
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateController(IMediator mediator) => _mediator = mediator;

        [HttpGet("all_templates")]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetAllTemplatesQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var template = await _mediator.Send(new GetTemplateByIdQuery(id));
            return template == null ? NotFound() : Ok(template);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Template template)
        {
            await _mediator.Send(new CreateTemplateCommand(template));
            return CreatedAtAction(nameof(GetById), new { id = template.Id }, template);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Template template)
        {
            if (id != template.Id) return BadRequest();
            await _mediator.Send(new UpdateTemplateCommand(template));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTemplateCommand(id));
            return NoContent();
        }
    }

}
