using HromadaWEB.DB.Data;
using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.Indicators
{
    public class IndicatorRepository : IIndicatorRepository
    {
        private readonly AppDbContext _context;

        public IndicatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Indicator>> GetAllAsync()
        {
            return await _context.Indicators.ToListAsync();
        }

        public async Task<Indicator?> GetByIdAsync(Guid id)
        {
            return await _context.Indicators.FindAsync(id);
        }

        public async Task AddAsync(Indicator indicator)
        {
            await _context.Indicators.AddAsync(indicator);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Indicator indicator)
        {
            _context.Indicators.Update(indicator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Indicators.FindAsync(id);
            if (entity != null)
            {
                _context.Indicators.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
