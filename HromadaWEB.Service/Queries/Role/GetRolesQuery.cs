using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HromadaWEB.Service.Queries.Role
{
    public record GetRolesQuery() : IRequest<IEnumerable<HromadaWEB.Models.Entities.Role>>;
}
