using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Indicators
{
    public record GetAllIndicatorsQuery : IRequest<IEnumerable<Indicator>>;
}
