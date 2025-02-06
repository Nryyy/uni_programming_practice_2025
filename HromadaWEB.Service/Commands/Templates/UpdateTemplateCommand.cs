using HromadaWEB.Models.Entities;
using MediatR;

namespace HromadaWEB.Service.Commands.Templates
{
    public record UpdateTemplateCommand(Template Template) : IRequest;
}
