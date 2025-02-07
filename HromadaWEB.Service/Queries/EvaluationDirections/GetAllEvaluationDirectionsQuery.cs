using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.EvaluationDirections
{
    public record GetAllEvaluationDirectionsQuery : IRequest<IEnumerable<EvaluationDirection>>;
}
