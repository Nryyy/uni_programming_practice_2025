using HromadaWEB.Infrastructure.Interfaces.IndicatorAnswer;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.IndicatorAnswer
{
    public class IndicatorAnswersService : IIndicatorAnswersService
    {
        private readonly IIndicatorAnswersRepository _repository;

        public IndicatorAnswersService(IIndicatorAnswersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IndicatorAnswers>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IndicatorAnswers> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(IndicatorAnswers entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(IndicatorAnswers entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
