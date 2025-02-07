using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.EvaluationDirections;
using MediatR;

namespace HromadaWEB.Service.Handlers.EvaluationDirections
{
    public class GetEvaluationDirectionByIdHandler : IRequestHandler<GetEvaluationDirectionByIdQuery, EvaluationDirection?>
    {
        private readonly IEvaluationDirectionService _service;

        public GetEvaluationDirectionByIdHandler(IEvaluationDirectionService service)
        {
            _service = service;
        }

        public async Task<EvaluationDirection?> Handle(GetEvaluationDirectionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
