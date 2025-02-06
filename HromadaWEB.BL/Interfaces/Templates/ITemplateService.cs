using HromadaWEB.Models.Entities;

namespace HromadaWEB.Infrastructure.Interfaces.Templates
{
    public interface ITemplateService
    {
        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task<Template?> GetTemplateByIdAsync(Guid id);
        Task CreateTemplateAsync(Template template);
        Task UpdateTemplateAsync(Template template);
        Task DeleteTemplateAsync(Guid id);
    }
}
