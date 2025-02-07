using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Indicators;
using MediatR;

namespace HromadaWEB.Service.Handlers.Indicators
{
    public class GetAllIndicatorsHandler : IRequestHandler<GetAllIndicatorsQuery, IEnumerable<Indicator>>
    {
        private readonly IIndicatorService _service;

        public GetAllIndicatorsHandler(IIndicatorService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Indicator>> Handle(GetAllIndicatorsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }

}
