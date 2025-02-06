using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Service.Commands.Templates;
using MediatR;

namespace HromadaWEB.Service.Handlers.Templates
{
    public class UpdateTemplateHandler : IRequestHandler<UpdateTemplateCommand>
    {
        private readonly ITemplateService _service;
        public UpdateTemplateHandler(ITemplateService service) => _service = service;

        public async Task Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
            => await _service.UpdateTemplateAsync(request.Template);
    }
}
