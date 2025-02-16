using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Evaluations
{
    public interface IEvaluationRepository
    {
        Task<IEnumerable<Evaluation>> GetAllAsync();
        Task<Evaluation> GetByIdAsync(Guid id);
        Task AddAsync(Evaluation evaluation);
        Task UpdateAsync(Evaluation evaluation);
        Task DeleteAsync(Guid id);
    }
}
