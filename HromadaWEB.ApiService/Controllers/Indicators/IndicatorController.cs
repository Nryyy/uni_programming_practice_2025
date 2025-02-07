using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.Indicators;
using HromadaWEB.Service.Queries.Indicators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.Indicators
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndicatorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllIndicatorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetIndicatorByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Indicator indicator)
        {
            await _mediator.Send(new CreateIndicatorCommand(indicator));
            return CreatedAtAction(nameof(GetById), new { id = indicator.Id }, indicator);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Indicator indicator)
        {
            await _mediator.Send(new UpdateIndicatorCommand(indicator));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteIndicatorCommand(id));
            return NoContent();
        }
    }
}
