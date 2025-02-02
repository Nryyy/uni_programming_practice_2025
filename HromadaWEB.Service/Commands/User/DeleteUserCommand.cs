using MediatR;

namespace HromadaWEB.Service.Commands.User
{
    public record DeleteUserCommand(Guid Id) : IRequest;
}
