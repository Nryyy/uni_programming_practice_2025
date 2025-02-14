using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.Review;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.Review
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reviews> GetByIdAsync(Guid id) =>
            await _context.Reviews.FindAsync(id);

        public async Task<IEnumerable<Reviews>> GetAllAsync() =>
            await _context.Reviews.ToListAsync();

        public async Task AddAsync(Reviews review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reviews review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }

}
