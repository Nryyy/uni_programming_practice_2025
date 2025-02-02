namespace HromadaWEB.Infrastructure.Interfaces.Role
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Models.Entities.Role>> GetRolesAsync();
    }
}
