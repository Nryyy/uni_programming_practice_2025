using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Service.Commands.Review;
using MediatR;

namespace HromadaWEB.Service.Handlers.Review
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IReviewRepository _repository;

        public UpdateReviewHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(request.Review);
        }
    }
}
