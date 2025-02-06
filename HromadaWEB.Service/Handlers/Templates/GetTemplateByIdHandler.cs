using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Templates;
using MediatR;

namespace HromadaWEB.Service.Handlers.Templates
{
    public class GetTemplateByIdHandler : IRequestHandler<GetTemplateByIdQuery, Template?>
    {
        private readonly ITemplateService _service;
        public GetTemplateByIdHandler(ITemplateService service) => _service = service;

        public async Task<Template?> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
            => await _service.GetTemplateByIdAsync(request.Id);
    }
}
