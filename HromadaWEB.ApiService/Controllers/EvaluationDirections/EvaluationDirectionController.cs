using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.EvaluationDirections;
using HromadaWEB.Service.Queries.EvaluationDirections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.EvaluationDirections
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationDirectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EvaluationDirectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEvaluationDirectionsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetEvaluationDirectionByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluationDirection evaluationDirection)
        {
            await _mediator.Send(new CreateEvaluationDirectionCommand(evaluationDirection));
            return CreatedAtAction(nameof(GetById), new { id = evaluationDirection.Id }, evaluationDirection);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EvaluationDirection evaluationDirection)
        {
            await _mediator.Send(new UpdateEvaluationDirectionCommand(evaluationDirection));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEvaluationDirectionCommand(id));
            return NoContent();
        }
    }
}
