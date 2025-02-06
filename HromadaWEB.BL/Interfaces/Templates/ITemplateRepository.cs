using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Templates
{
    public interface ITemplateRepository
    {
        Task<IEnumerable<Template>> GetAllAsync();
        Task<Template?> GetByIdAsync(Guid id);
        Task AddAsync(Template template);
        Task UpdateAsync(Template template);
        Task DeleteAsync(Guid id);
    }
}
