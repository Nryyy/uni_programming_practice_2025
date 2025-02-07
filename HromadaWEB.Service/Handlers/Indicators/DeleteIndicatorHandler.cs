using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Service.Commands.Indicators;
using MediatR;

namespace HromadaWEB.Service.Handlers.Indicators
{
    public class DeleteIndicatorHandler : IRequestHandler<DeleteIndicatorCommand>
    {
        private readonly IIndicatorService _service;

        public DeleteIndicatorHandler(IIndicatorService service)
        {
            _service = service;
        }

        public async Task Handle(DeleteIndicatorCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);
        }
    }
}
