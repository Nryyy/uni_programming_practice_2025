using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Evaluations
{
    public interface IEvaluationService
    {
        Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync();
        Task<Evaluation> GetEvaluationByIdAsync(Guid id);
        Task CreateEvaluationAsync(Evaluation evaluation);
        Task UpdateEvaluationAsync(Evaluation evaluation);
        Task DeleteEvaluationAsync(Guid id);
    }
}
