using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Review;
using MediatR;

namespace HromadaWEB.Service.Handlers.Review
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, Reviews>
    {
        private readonly IReviewRepository _repository;

        public GetReviewByIdHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reviews> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken) =>
            await _repository.GetByIdAsync(request.Id);
    }
}
