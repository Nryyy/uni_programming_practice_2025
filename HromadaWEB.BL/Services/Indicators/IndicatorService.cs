using HromadaWEB.Infrastructure.Interfaces.Indicators;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.Indicators
{
    public class IndicatorService : IIndicatorService
    {
        private readonly IIndicatorRepository _repository;

        public IndicatorService(IIndicatorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Indicator>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Indicator?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
        public async Task AddAsync(Indicator indicator) => await _repository.AddAsync(indicator);
        public async Task UpdateAsync(Indicator indicator) => await _repository.UpdateAsync(indicator);
        public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
