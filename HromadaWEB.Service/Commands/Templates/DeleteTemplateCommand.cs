using MediatR;

namespace HromadaWEB.Service.Commands.Templates
{
    public record DeleteTemplateCommand(Guid Id) : IRequest;
}
