using MediatR;

namespace HromadaWEB.Service.Commands.IndicatorAnswer
{
    public record DeleteIndicatorAnswerCommand(Guid Id) : IRequest;
}
