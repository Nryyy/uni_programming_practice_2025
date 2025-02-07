using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.EvaluationDirections
{
    public record UpdateEvaluationDirectionCommand(EvaluationDirection EvaluationDirection) : IRequest;
}
