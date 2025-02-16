using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Service.Commands.Evaluations;
using MediatR;

namespace HromadaWEB.Service.Handlers.Evaluations
{
    public class CreateEvaluationHandler : IRequestHandler<CreateEvaluationCommand>
    {
        private readonly IEvaluationService _evaluationService;

        public CreateEvaluationHandler(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            await _evaluationService.CreateEvaluationAsync(request.Evaluation);
        }
    }
}
