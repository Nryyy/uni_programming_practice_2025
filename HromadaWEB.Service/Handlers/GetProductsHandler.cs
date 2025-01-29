using HromadaWEB.BL.Interfaces;
using HromadaWEB.Models.Entities;
using HromadaWEB.Service.Queries;
using MediatR;

namespace HromadaWEB.Service.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductModel>>
    {
        private readonly IProductService _productService;

        public GetProductsHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProducts();
        }
    }
}
