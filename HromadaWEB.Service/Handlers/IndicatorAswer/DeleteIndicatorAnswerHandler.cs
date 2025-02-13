using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Service.Commands.IndicatorAnswer;
using MediatR;

namespace HromadaWEB.Service.Handlers.IndicatorAswer
{
    public class DeleteIndicatorAnswerHandler : IRequestHandler<DeleteIndicatorAnswerCommand>
    {
        private readonly IIndicatorAnswersService _service;

        public DeleteIndicatorAnswerHandler(IIndicatorAnswersService service)
        {
            _service = service;
        }

        public async Task Handle(DeleteIndicatorAnswerCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.Id);
        }
    }
}
