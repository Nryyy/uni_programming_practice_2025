using MediatR;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Service.Queries
{
    public record  GetProductsQuery : IRequest<List<ProductModel>>;
}
