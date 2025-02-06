using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Templates
{
    public record GetAllTemplatesQuery : IRequest<IEnumerable<Template>>;
}
