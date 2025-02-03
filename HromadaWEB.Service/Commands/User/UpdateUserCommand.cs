using MediatR;

namespace HromadaWEB.Service.Commands.User
{
    public record UpdateUserCommand(Models.Entities.User User) : IRequest;
}
