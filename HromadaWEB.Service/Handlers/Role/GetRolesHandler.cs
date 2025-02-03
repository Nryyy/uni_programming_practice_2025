using HromadaWEB.Infrastructure.Interfaces.Role;
using HromadaWEB.Service.Queries.Role;
using MediatR;

namespace HromadaWEB.Service.Handlers.Role
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<Models.Entities.Role>>
    {
        private readonly IRoleService _roleService;

        public GetRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IEnumerable<Models.Entities.Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleService.GetRolesAsync();
        }
    }
}
