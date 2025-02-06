using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Models.Entities;
using HromadaWEB.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace HromadaWEB.Infrastructure.Repositories.Templates
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _context;

        public TemplateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Template>> GetAllAsync()
        {
            return await _context.Templates.Include(t => t.CreatedBy).ToListAsync();
        }

        public async Task<Template?> GetByIdAsync(Guid id)
        {
            return await _context.Templates.Include(t => t.CreatedBy).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Template template)
        {
            _context.Templates.Add(template);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Template template)
        {
            _context.Templates.Update(template);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template != null)
            {
                _context.Templates.Remove(template);
                await _context.SaveChangesAsync();
            }
        }
    }
}
