using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.EvaluationDirections
{
    public record GetEvaluationDirectionByIdQuery(int Id) : IRequest<EvaluationDirection?>;
}
