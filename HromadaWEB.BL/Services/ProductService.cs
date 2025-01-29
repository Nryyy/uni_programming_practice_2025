using HromadaWEB.BL.Interfaces;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.BL.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return productRepository.GetProducts();
        }
    }
}
