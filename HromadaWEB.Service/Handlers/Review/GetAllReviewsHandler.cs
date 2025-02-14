using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Review;
using MediatR;

namespace HromadaWEB.Service.Handlers.Review
{
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Reviews>>
    {
        private readonly IReviewRepository _repository;

        public GetAllReviewsHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Reviews>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken) =>
            await _repository.GetAllAsync();
    }
}
