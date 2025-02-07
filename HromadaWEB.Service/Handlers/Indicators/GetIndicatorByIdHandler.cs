using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Indicators;
using MediatR;

namespace HromadaWEB.Service.Handlers.Indicators
{
    public class GetIndicatorByIdHandler : IRequestHandler<GetIndicatorByIdQuery, Indicator?>
    {
        private readonly IIndicatorService _service;

        public GetIndicatorByIdHandler(IIndicatorService service)
        {
            _service = service;
        }

        public async Task<Indicator?> Handle(GetIndicatorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
