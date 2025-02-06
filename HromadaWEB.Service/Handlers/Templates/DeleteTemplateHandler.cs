using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Service.Commands.Templates;
using MediatR;

namespace HromadaWEB.Service.Handlers.Templates
{
    public class DeleteTemplateHandler : IRequestHandler<DeleteTemplateCommand>
    {
        private readonly ITemplateService _service;
        public DeleteTemplateHandler(ITemplateService service) => _service = service;

        public async Task Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
            => await _service.DeleteTemplateAsync(request.Id);
    }
}
