using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Service.Commands.Indicators;
using MediatR;

namespace HromadaWEB.Service.Handlers.Indicators
{
    public class CreateIndicatorHandler : IRequestHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorService _service;

        public CreateIndicatorHandler(IIndicatorService service)
        {
            _service = service;
        }

        public async Task Handle(CreateIndicatorCommand request, CancellationToken cancellationToken)
        {
            await _service.AddAsync(request.Indicator);
        }
    }
}
