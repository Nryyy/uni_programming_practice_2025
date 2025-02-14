using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Review
{
    public record GetAllReviewsQuery() : IRequest<IEnumerable<Reviews>>;
}
