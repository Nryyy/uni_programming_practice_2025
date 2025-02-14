using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Review
{
    public interface IReviewRepository
    {
        Task<Reviews> GetByIdAsync(Guid id);
        Task<IEnumerable<Reviews>> GetAllAsync();
        Task AddAsync(Reviews review);
        Task UpdateAsync(Reviews review);
        Task DeleteAsync(Guid id);
    }
}
