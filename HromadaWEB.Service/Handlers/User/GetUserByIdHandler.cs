using HromadaWEB.Core.Services;
using HromadaWEB.Service.Queries.User;
using MediatR;

namespace HromadaWEB.Service.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, HromadaWEB.Models.Entities.User?>
    {
        private readonly IUserService _userService;

        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HromadaWEB.Models.Entities.User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByIdAsync(request.Id);
        }
    }
}
