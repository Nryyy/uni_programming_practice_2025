public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public RoleDto? Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsBlocked { get; set; }
}
