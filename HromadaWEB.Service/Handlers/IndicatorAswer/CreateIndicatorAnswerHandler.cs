using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Service.Commands.IndicatorAnswer;
using MediatR;

namespace HromadaWEB.Service.Handlers.IndicatorAswer
{
    public class CreateIndicatorAnswerHandler : IRequestHandler<CreateIndicatorAnswerCommand>
    {
        private readonly IIndicatorAnswersService _service;

        public CreateIndicatorAnswerHandler(IIndicatorAnswersService service)
        {
            _service = service;
        }

        public async Task Handle(CreateIndicatorAnswerCommand request, CancellationToken cancellationToken)
        {
            await _service.AddAsync(request.Answer);
        }
    }
}
