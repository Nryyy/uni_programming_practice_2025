using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Review
{
    public record UpdateReviewCommand(Reviews Review) : IRequest;
}
