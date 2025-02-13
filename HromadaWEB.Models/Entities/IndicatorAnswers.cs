namespace HromadaWEB.Models.Entities
{
    public class IndicatorAnswers
    {
        public Guid Id { get; set; }
        public Guid IndicatorId { get; set; }
        public Indicator Indicator { get; set; }
        public Guid ResponserId { get; set; }
        public User Responser { get; set; }
        public int AnswerStatusId { get; set; }
        public AnswerStatus AnswerStatus { get; set; }
        public decimal Score { get; set; }
        public string AnswerText { get; set; }
    }
}
