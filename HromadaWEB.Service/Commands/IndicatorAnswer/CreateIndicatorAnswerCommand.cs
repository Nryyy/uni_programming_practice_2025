using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.IndicatorAnswer
{
    public record CreateIndicatorAnswerCommand(IndicatorAnswers Answer) : IRequest;
}
