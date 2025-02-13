using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.IndicatorAnswer
{
    public record GetIndicatorAnswersQuery(Guid Id) : IRequest<IndicatorAnswers>;
}
