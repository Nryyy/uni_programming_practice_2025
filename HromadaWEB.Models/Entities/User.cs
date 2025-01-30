namespace HromadaWEB.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsBlocked { get; set; } = false;
    }
}
