using HromadaWEB.Core.Services;
using HromadaWEB.Service.Commands.User;
using MediatR;

namespace HromadaWEB.Service.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;

        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUserAsync(request.User);
        }
    }
}
