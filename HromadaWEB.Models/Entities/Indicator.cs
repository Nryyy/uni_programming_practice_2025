namespace HromadaWEB.Models.Entities
{
    public class Indicator
    {
        public Guid Id { get; set; }

        public Guid DirectionId { get; set; }
        public EvaluationDirection Direction { get; set; }

        public Guid TemplateId { get; set; }
        public Template Template { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Background { get; set; }
        public string Source { get; set; }

        public decimal MaxScore { get; set; }
    }
}
