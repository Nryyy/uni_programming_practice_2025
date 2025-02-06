using HromadaWEB.Infrastructure.Interfaces.Templates;
using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Services.Templates
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;

        public TemplateService(ITemplateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Template>> GetAllTemplatesAsync() => await _repository.GetAllAsync();

        public async Task<Template?> GetTemplateByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

        public async Task CreateTemplateAsync(Template template) => await _repository.AddAsync(template);

        public async Task UpdateTemplateAsync(Template template) => await _repository.UpdateAsync(template);

        public async Task DeleteTemplateAsync(Guid id) => await _repository.DeleteAsync(id);
    }
}
