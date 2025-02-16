using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Evaluations
{
    public record GetAllEvaluationsQuery : IRequest<IEnumerable<Evaluation>>;
}
