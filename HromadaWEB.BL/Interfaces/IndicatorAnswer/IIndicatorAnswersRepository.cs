using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer
{
    public interface IIndicatorAnswersRepository
    {
        Task<IndicatorAnswers> GetByIdAsync(Guid id);
        Task<IEnumerable<IndicatorAnswers>> GetAllAsync();
        Task AddAsync(IndicatorAnswers entity);
        Task UpdateAsync(IndicatorAnswers entity);
        Task DeleteAsync(Guid id);
    }
}
