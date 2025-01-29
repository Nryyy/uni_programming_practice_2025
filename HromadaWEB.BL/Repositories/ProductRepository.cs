using HromadaWEB.BL.Interfaces;
using HromadaWEB.BL.Data;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.BL.Repositories
{
    public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
        public Task<List<ProductModel>> GetProducts()
        {
            return dbContext.Products.ToListAsync();
        }
    }
}
