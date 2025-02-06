namespace HromadaWEB.Models.DTOs.Templates
{
    public class TemplateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CreatedById { get; set; } 
        public DateTime CreatedAt { get; set; }
    }

}
