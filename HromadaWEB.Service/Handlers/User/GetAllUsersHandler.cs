using HromadaWEB.Core.Services;
using HromadaWEB.Service.Queries.User;
using MediatR;
namespace HromadaWEB.Service.Handlers.User
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<Models.Entities.User>>
    {
        private readonly IUserService _userService;

        public GetAllUsersHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<Models.Entities.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsersAsync();
        }
    }
}
