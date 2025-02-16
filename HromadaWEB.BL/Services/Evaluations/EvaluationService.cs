using HromadaWEB.Infrastructure.Interfaces.Evaluations;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.Evaluations
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<IEnumerable<Evaluation>> GetAllEvaluationsAsync()
        {
            return await _evaluationRepository.GetAllAsync();
        }

        public async Task<Evaluation> GetEvaluationByIdAsync(Guid id)
        {
            return await _evaluationRepository.GetByIdAsync(id);
        }

        public async Task CreateEvaluationAsync(Evaluation evaluation)
        {
            await _evaluationRepository.AddAsync(evaluation);
        }

        public async Task UpdateEvaluationAsync(Evaluation evaluation)
        {
            await _evaluationRepository.UpdateAsync(evaluation);
        }

        public async Task DeleteEvaluationAsync(Guid id)
        {
            await _evaluationRepository.DeleteAsync(id);
        }
    }
}
