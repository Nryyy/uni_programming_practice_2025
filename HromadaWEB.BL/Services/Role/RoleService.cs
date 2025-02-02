using HromadaWEB.Infrastructure.Interfaces.Role;

namespace HromadaWEB.Infrastructure.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<IEnumerable<Models.Entities.Role>> GetRolesAsync()
        {
            return await _roleRepository.GetRolesAsync();
        }
    }
}
