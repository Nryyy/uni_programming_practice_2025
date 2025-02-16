namespace HromadaWEB.Models.Entities
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public decimal Score { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
