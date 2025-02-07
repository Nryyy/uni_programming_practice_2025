using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Indicators
{
    public interface IIndicatorService
    {
        Task<IEnumerable<Indicator>> GetAllAsync();
        Task<Indicator?> GetByIdAsync(Guid id);
        Task AddAsync(Indicator indicator);
        Task UpdateAsync(Indicator indicator);
        Task DeleteAsync(Guid id);
    }
}
