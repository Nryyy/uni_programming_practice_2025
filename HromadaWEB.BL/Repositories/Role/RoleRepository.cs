using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.Role;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Entities.Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
