using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Review
{
    public record CreateReviewCommand(Reviews Review) : IRequest;
}
