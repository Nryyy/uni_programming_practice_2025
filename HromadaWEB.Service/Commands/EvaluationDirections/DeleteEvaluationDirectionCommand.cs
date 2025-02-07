using MediatR;

namespace HromadaWEB.Service.Commands.EvaluationDirections
{
    public record DeleteEvaluationDirectionCommand(int Id) : IRequest;
}
