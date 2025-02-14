using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Review
{
    public interface IReviewService
    {
        Task<Reviews> GetReviewByIdAsync(Guid id);
        Task<IEnumerable<Reviews>> GetAllReviewsAsync();
        Task AddReviewAsync(Reviews review);
        Task UpdateReviewAsync(Reviews review);
        Task DeleteReviewAsync(Guid id);
    }
}
