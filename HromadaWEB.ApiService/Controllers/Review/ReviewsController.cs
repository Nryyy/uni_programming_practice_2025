using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Commands.Review;
using HromadaWEB.Service.Queries.Review;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HromadaWEB.ApiService.Controllers.Review
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _mediator.Send(new GetAllReviewsQuery());
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _mediator.Send(new GetReviewByIdQuery(id));
            return review != null ? Ok(review) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Reviews review)
        {
            if (review == null) return BadRequest();
            await _mediator.Send(new CreateReviewCommand(review));
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Reviews review)
        {
            if (id != review.Id) return BadRequest();
            await _mediator.Send(new UpdateReviewCommand(review));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteReviewCommand(id));
            return NoContent();
        }
    }

}
