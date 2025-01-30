using HromadaWEB.Models.Entities;

namespace HromadaWEB.BL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetProducts();
    }
}
