using HromadaWEB.Core.Services;
using HromadaWEB.Service.Commands.User;
using MediatR;

namespace HromadaWEB.Service.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.CreateUserAsync(request.User);
        }
    }
}
