using MediatR;

namespace HromadaWEB.Service.Queries.Role
{
    public record GetRolesQuery() : IRequest<IEnumerable<HromadaWEB.Models.Entities.Role>>;
}
