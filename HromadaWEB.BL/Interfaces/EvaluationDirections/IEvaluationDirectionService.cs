using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.EvaluationDirections
{
    public interface IEvaluationDirectionService
    {
        Task<IEnumerable<EvaluationDirection>> GetAllAsync();
        Task<EvaluationDirection?> GetByIdAsync(int id);
        Task AddAsync(EvaluationDirection evaluationDirection);
        Task UpdateAsync(EvaluationDirection evaluationDirection);
        Task DeleteAsync(int id);
    }
}
