using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Evaluations;
using MediatR;

namespace HromadaWEB.Service.Handlers.Evaluations
{
    public class GetEvaluationByIdHandler : IRequestHandler<GetEvaluationByIdQuery, Evaluation>
    {
        private readonly IEvaluationService _evaluationService;

        public GetEvaluationByIdHandler(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task<Evaluation> Handle(GetEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _evaluationService.GetEvaluationByIdAsync(request.Id);
        }
    }
}
