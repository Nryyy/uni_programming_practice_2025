using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Service.Commands.Evaluations;
using MediatR;

namespace HromadaWEB.Service.Handlers.Evaluations
{
    public class UpdateEvaluationHandler : IRequestHandler<UpdateEvaluationCommand>
    {
        private readonly IEvaluationService _evaluationService;

        public UpdateEvaluationHandler(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task Handle(UpdateEvaluationCommand request, CancellationToken cancellationToken)
        {
            await _evaluationService.UpdateEvaluationAsync(request.Evaluation);
        }
    }
}
