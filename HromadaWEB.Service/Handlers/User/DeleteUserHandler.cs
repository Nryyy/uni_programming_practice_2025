using HromadaWEB.Core.Services;
using HromadaWEB.Service.Commands.User;
using MediatR;

namespace HromadaWEB.Service.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;

        public DeleteUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteUserAsync(request.Id);
        }
    }
}
