using MediatR;

namespace HromadaWEB.Service.Commands.Indicators
{
    public record DeleteIndicatorCommand(Guid Id) : IRequest;
}
