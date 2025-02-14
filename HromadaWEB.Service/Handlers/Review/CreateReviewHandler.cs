using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Service.Commands.Review;
using MediatR;

namespace HromadaWEB.Service.Handlers.Review
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IReviewRepository _repository;

        public CreateReviewHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Review);
        }
    }
}
