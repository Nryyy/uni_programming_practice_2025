using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Reviews> GetReviewByIdAsync(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Reviews>> GetAllReviewsAsync() =>
            await _repository.GetAllAsync();

        public async Task AddReviewAsync(Reviews review) =>
            await _repository.AddAsync(review);

        public async Task UpdateReviewAsync(Reviews review) =>
            await _repository.UpdateAsync(review);

        public async Task DeleteReviewAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

}
