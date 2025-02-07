using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.EvaluationDirections;
using MediatR;

namespace HromadaWEB.Service.Handlers.EvaluationDirections
{
    public class GetAllEvaluationDirectionsHandler : IRequestHandler<GetAllEvaluationDirectionsQuery, IEnumerable<EvaluationDirection>>
    {
        private readonly IEvaluationDirectionService _service;

        public GetAllEvaluationDirectionsHandler(IEvaluationDirectionService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<EvaluationDirection>> Handle(GetAllEvaluationDirectionsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}
