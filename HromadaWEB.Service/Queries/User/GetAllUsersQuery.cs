using MediatR;

namespace HromadaWEB.Service.Queries.User
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<HromadaWEB.Models.Entities.User>>;
}
