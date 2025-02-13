using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.IndicatorAnswer
{
    public record UpdateIndicatorAnswerCommand(IndicatorAnswers Answer) : IRequest;
}
