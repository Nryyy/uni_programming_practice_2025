using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Queries.Templates
{
    public record GetTemplateByIdQuery(Guid Id) : IRequest<Template?>;
}
