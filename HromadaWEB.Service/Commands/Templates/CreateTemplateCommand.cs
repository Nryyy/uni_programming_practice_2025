using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Templates
{
    public record CreateTemplateCommand(Template Template) : IRequest;
}
