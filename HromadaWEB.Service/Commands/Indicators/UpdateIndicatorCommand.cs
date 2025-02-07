using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Indicators
{
    public record UpdateIndicatorCommand(Indicator Indicator) : IRequest;
}
