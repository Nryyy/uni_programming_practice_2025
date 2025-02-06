using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries.Templates;
using MediatR;

public class GetAllTemplatesHandler : IRequestHandler<GetAllTemplatesQuery, IEnumerable<Template>>
{
    private readonly ITemplateService _service;
    public GetAllTemplatesHandler(ITemplateService service) => _service = service;

    public async Task<IEnumerable<Template>> Handle(GetAllTemplatesQuery request, CancellationToken cancellationToken)
        => await _service.GetAllTemplatesAsync();
}
