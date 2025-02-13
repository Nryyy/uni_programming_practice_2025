using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.IndicatorAnswer;
using HromadaWEB.Service.Queries.IndicatorAnswer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.IndicatorAnswer
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndicatorAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndicatorAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllIndicatorAnswersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetIndicatorAnswersQuery(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IndicatorAnswers answer)
        {
            await _mediator.Send(new CreateIndicatorAnswerCommand(answer));
            return CreatedAtAction(nameof(Get), new { id = answer.Id }, answer);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IndicatorAnswers answer)
        {
            await _mediator.Send(new UpdateIndicatorAnswerCommand(answer));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteIndicatorAnswerCommand(id));
            return NoContent();
        }
    }
}
