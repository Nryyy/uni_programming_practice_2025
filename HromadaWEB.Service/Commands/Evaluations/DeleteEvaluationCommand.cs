using MediatR;

namespace HromadaWEB.Service.Commands.Evaluations
{
    public record DeleteEvaluationCommand(Guid Id) : IRequest;
}
