using HromadaWEB.Infrastructure.Interfaces.EvaluationDirections;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.EvaluationDirections
{
    public class EvaluationDirectionService : IEvaluationDirectionService
    {
        private readonly IEvaluationDirectionRepository _repository;

        public EvaluationDirectionService(IEvaluationDirectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EvaluationDirection>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<EvaluationDirection?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(EvaluationDirection evaluationDirection) => await _repository.AddAsync(evaluationDirection);
        public async Task UpdateAsync(EvaluationDirection evaluationDirection) => await _repository.UpdateAsync(evaluationDirection);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
