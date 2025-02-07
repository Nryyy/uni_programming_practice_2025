using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Service.Commands.EvaluationDirections;
using MediatR;

namespace HromadaWEB.Service.Handlers.EvaluationDirections
{
    public class UpdateEvaluationDirectionHandler : IRequestHandler<UpdateEvaluationDirectionCommand>
    {
        private readonly IEvaluationDirectionService _service;

        public UpdateEvaluationDirectionHandler(IEvaluationDirectionService service)
        {
            _service = service;
        }

        public async Task Handle(UpdateEvaluationDirectionCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.EvaluationDirection);
        }
    }
}
