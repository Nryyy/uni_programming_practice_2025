using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer
{
    public interface IIndicatorAnswersService
    {
        Task<IEnumerable<IndicatorAnswers>> GetAllAsync();
        Task<IndicatorAnswers> GetByIdAsync(Guid id);
        Task AddAsync(IndicatorAnswers entity);
        Task UpdateAsync(IndicatorAnswers entity);
        Task DeleteAsync(Guid id);
    }
}
