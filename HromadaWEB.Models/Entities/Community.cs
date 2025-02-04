namespace HromadaWEB.Models.Entities
{
    public class Community
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public User Representive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
