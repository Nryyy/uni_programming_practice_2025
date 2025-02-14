using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Review
{
    public record GetReviewByIdQuery(Guid Id) : IRequest<Reviews>;
}
