using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Evaluations
{
    public record GetEvaluationByIdQuery(Guid Id) : IRequest<Evaluation>;
}
