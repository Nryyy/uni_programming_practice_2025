using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Service.Commands.EvaluationDirections;
using MediatR;

namespace HromadaWEB.Service.Handlers.EvaluationDirections
{
    public class DeleteEvaluationDirectionHandler : IRequestHandler<DeleteEvaluationDirectionCommand>
    {
        private readonly IEvaluationDirectionService _service;

        public DeleteEvaluationDirectionHandler(IEvaluationDirectionService service)
        {
            _service = service;
        }

        public async Task Handle(DeleteEvaluationDirectionCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);
        }
    }
}
