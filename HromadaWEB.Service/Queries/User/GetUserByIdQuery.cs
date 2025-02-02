using MediatR;

namespace HromadaWEB.Service.Queries.User
{
    public record GetUserByIdQuery(Guid Id) : IRequest<HromadaWEB.Models.Entities.User?>;
}
