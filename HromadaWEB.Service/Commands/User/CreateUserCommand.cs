using MediatR;

namespace HromadaWEB.Service.Commands.User
{
    public record CreateUserCommand(Models.Entities.User User) : IRequest;
}
