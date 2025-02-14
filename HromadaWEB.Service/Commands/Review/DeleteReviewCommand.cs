using MediatR;

namespace HromadaWEB.Service.Commands.Review
{
    public record DeleteReviewCommand(Guid Id) : IRequest;
}
