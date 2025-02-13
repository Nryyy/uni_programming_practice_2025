using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Service.Commands.IndicatorAnswer;
using MediatR;

namespace HromadaWEB.Service.Handlers.IndicatorAswer
{
    public class UpdateIndicatorAnswerHandler : IRequestHandler<UpdateIndicatorAnswerCommand>
    {
        private readonly IIndicatorAnswersService _service;

        public UpdateIndicatorAnswerHandler(IIndicatorAnswersService service)
        {
            _service = service;
        }

        public async Task Handle(UpdateIndicatorAnswerCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Answer);
        }
    }
}
