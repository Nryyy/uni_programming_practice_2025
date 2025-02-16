using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Evaluations;
using MediatR;

namespace HromadaWEB.Service.Handlers.Evaluations
{
    public class GetAllEvaluationsHandler : IRequestHandler<GetAllEvaluationsQuery, IEnumerable<Evaluation>>
    {
        private readonly IEvaluationService _evaluationService;

        public GetAllEvaluationsHandler(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public async Task<IEnumerable<Evaluation>> Handle(GetAllEvaluationsQuery request, CancellationToken cancellationToken)
        {
            return await _evaluationService.GetAllEvaluationsAsync();
        }
    }
}
