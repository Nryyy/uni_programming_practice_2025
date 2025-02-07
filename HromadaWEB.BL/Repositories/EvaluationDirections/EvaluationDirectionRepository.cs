using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.EvaluationDirections
{
    public class EvaluationDirectionRepository : IEvaluationDirectionRepository
    {
        private readonly AppDbContext _context;

        public EvaluationDirectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EvaluationDirection>> GetAllAsync()
        {
            return await _context.EvaluationDirections.ToListAsync();
        }

        public async Task<EvaluationDirection?> GetByIdAsync(int id)
        {
            return await _context.EvaluationDirections.FindAsync(id);
        }

        public async Task AddAsync(EvaluationDirection evaluationDirection)
        {
            await _context.EvaluationDirections.AddAsync(evaluationDirection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EvaluationDirection evaluationDirection)
        {
            _context.EvaluationDirections.Update(evaluationDirection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.EvaluationDirections.FindAsync(id);
            if (entity != null)
            {
                _context.EvaluationDirections.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
