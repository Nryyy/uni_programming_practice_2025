namespace HromadaWEB.Models.Entities
{
    public class Reviews
    {
        public Guid Id { get; set; }
        public Guid IndicatorAnswerId { get; set; }
        public IndicatorAnswers IndicatorAnswer { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
