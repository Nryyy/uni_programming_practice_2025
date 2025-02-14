using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Service.Commands.Review;
using MediatR;

namespace HromadaWEB.Service.Handlers.Review
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _repository;

        public DeleteReviewHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
