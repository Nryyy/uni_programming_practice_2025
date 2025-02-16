using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.Evaluations;
using HromadaWEB.Service.Queries.Evaluations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.Evaluations
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EvaluationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluations = await _mediator.Send(new GetAllEvaluationsQuery());
            return Ok(evaluations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var evaluation = await _mediator.Send(new GetEvaluationByIdQuery(id));
            if (evaluation == null)
            {
                return NotFound();
            }
            return Ok(evaluation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Evaluation evaluation)
        {
            await _mediator.Send(new CreateEvaluationCommand(evaluation));
            return CreatedAtAction(nameof(GetById), new { id = evaluation.Id }, evaluation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateEvaluationCommand(evaluation));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEvaluationCommand(id));
            return NoContent();
        }
    }
}
