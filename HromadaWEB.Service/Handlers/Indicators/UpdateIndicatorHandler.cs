using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Service.Commands.Indicators;
using MediatR;

namespace HromadaWEB.Service.Handlers.Indicators
{
    public class UpdateIndicatorHandler : IRequestHandler<UpdateIndicatorCommand>
    {
        private readonly IIndicatorService _service;

        public UpdateIndicatorHandler(IIndicatorService service)
        {
            _service = service;
        }

        public async Task Handle(UpdateIndicatorCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Indicator);
        }
    }
}
