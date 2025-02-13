using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.IndicatorAnswer
{
    public record GetAllIndicatorAnswersQuery() : IRequest<IEnumerable<IndicatorAnswers>>;
}
