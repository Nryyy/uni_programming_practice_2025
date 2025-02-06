using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Service.Commands.Templates;
using MediatR;

namespace HromadaWEB.Service.Handlers.Templates
{
    public class CreateTemplateHandler : IRequestHandler<CreateTemplateCommand>
    {
        private readonly ITemplateService _service;
        public CreateTemplateHandler(ITemplateService service) => _service = service;

        public async Task Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
            => await _service.CreateTemplateAsync(request.Template);
    }
}
