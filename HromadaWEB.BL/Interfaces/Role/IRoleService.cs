using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HromadaWEB.Infrastructure.Interfaces.Role
{
    public interface IRoleService
    {
        public Task<IEnumerable<Models.Entities.Role>> GetRolesAsync();
    }
}
