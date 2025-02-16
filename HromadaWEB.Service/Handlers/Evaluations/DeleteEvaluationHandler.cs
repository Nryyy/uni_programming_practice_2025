using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Service.Commands.Evaluations;
using MediatR;

namespace HromadaWEB.Service.Handlers.Evaluations
{
    public class DeleteEvaluationHandler : IRequestHandler<DeleteEvaluationCommand>
    {
        private readonly IEvaluationService _evaluationService;

        public DeleteEvaluationHandler(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task Handle(DeleteEvaluationCommand request, CancellationToken cancellationToken)
        {
            await _evaluationService.DeleteEvaluationAsync(request.Id);
        }
    }
}
