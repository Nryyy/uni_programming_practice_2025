using HromadaWEB.Models.Entities;

namespace HromadaWEB.BL.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProducts();
    }
}
