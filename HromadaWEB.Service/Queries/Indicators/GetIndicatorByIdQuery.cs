using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Indicators
{
    public record GetIndicatorByIdQuery(Guid Id) : IRequest<Indicator?>;
}
