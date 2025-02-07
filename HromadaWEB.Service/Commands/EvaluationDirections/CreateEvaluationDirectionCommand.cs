using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.EvaluationDirections
{
    public record CreateEvaluationDirectionCommand(EvaluationDirection EvaluationDirection) : IRequest;
}
