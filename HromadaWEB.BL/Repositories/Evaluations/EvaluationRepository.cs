using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.Evaluations
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly AppDbContext _context;

        public EvaluationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evaluation>> GetAllAsync()
        {
            return await _context.Evaluations.Include(e => e.User).ToListAsync();
        }

        public async Task<Evaluation> GetByIdAsync(Guid id)
        {
            return await _context.Evaluations.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Evaluation evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evaluation evaluation)
        {
            _context.Evaluations.Update(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
