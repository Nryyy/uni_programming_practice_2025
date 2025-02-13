using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.IndicatorAnswer;
using MediatR;

namespace HromadaWEB.Service.Handlers.IndicatorAswer
{
    public class GetIndicatorAnswersHandler : IRequestHandler<GetIndicatorAnswersQuery, IndicatorAnswers>
    {
        private readonly IIndicatorAnswersService _service;

        public GetIndicatorAnswersHandler(IIndicatorAnswersService service)
        {
            _service = service;
        }

        public async Task<IndicatorAnswers> Handle(GetIndicatorAnswersQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
