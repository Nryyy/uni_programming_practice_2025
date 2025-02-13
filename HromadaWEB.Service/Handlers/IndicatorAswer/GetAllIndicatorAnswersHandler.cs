using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.IndicatorAnswer;
using MediatR;

namespace HromadaWEB.Service.Handlers.IndicatorAswer
{
    public class GetAllIndicatorAnswersHandler : IRequestHandler<GetAllIndicatorAnswersQuery, IEnumerable<IndicatorAnswers>>
    {
        private readonly IIndicatorAnswersService _service;

        public GetAllIndicatorAnswersHandler(IIndicatorAnswersService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<IndicatorAnswers>> Handle(GetAllIndicatorAnswersQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}
