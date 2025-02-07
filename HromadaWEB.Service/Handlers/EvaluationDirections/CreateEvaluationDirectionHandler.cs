using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Service.Commands.EvaluationDirections;
using MediatR;

namespace HromadaWEB.Service.Handlers.EvaluationDirections
{
    public class CreateEvaluationDirectionHandler : IRequestHandler<CreateEvaluationDirectionCommand>
    {
        private readonly IEvaluationDirectionService _service;

        public CreateEvaluationDirectionHandler(IEvaluationDirectionService service)
        {
            _service = service;
        }

        public async Task Handle(CreateEvaluationDirectionCommand request, CancellationToken cancellationToken)
        {
            await _service.AddAsync(request.EvaluationDirection);
        }
    }
}
