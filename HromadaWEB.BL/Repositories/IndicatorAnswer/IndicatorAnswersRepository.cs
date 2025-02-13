using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.IndicatorAnswer
{
    public class IndicatorAnswersRepository : IIndicatorAnswersRepository
    {
        private readonly AppDbContext _context;

        public IndicatorAnswersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IndicatorAnswers> GetByIdAsync(Guid id)
        {
            return await _context.IndicatorAnswers.FindAsync(id);
        }

        public async Task<IEnumerable<IndicatorAnswers>> GetAllAsync()
        {
            return await _context.IndicatorAnswers.ToListAsync();
        }

        public async Task AddAsync(IndicatorAnswers entity)
        {
            await _context.IndicatorAnswers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IndicatorAnswers entity)
        {
            _context.IndicatorAnswers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.IndicatorAnswers.FindAsync(id);
            if (entity != null)
            {
                _context.IndicatorAnswers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
